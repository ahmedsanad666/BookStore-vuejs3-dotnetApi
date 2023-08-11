<template>
    <section class="min-h-screen">
      <h1 class="my-4 py-2 font-bold md:text-3xl text-2xl text-center">
اقسام الدورة      </h1>
  
      <base-spinner v-if="isLoading"></base-spinner>
      <div class="container py-4 my-3 md:px-2" v-else>
        <div>
          <button
            @click="addNew()"
            class="my-3 py-2 px-4 bg-slate-900 text-white"
          >
            اضافة
          </button>
        </div>
        <div class="relative overflow-x-auto shadow-md sm:rounded-lg">
          <table
            class="w-full text-sm text-left text-gray-500 dark:text-gray-400"
          >
            <thead
              class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400"
            >
              <tr>
                <th scope="col" class="px-6 py-3">عنوان الفصل</th>
                <th scope="col" class="px-6 py-3">الترتيب </th>
                <th scope="col" class="px-6 py-3">مخفى</th>
                <th scope="col" class="px-6 py-3"> عنوان اكورس</th>
                <th scope="col" class="px-6 py-3 text-center">التحكم</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(el, key) in allChapters" :key="key">
                <th
                  scope="row"
                  class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap"
                >
                  {{ el.name }}
                </th>
                <!-- <td class="px-6 py-4">{{ el.name }}</td> -->
                <td class="px-6 py-4">{{ el.index }}</td>
                <td class="px-6 py-4">{{ el.isHidden ?'غير مفعل ' : 'مفعل' }}</td>
                <td class="px-6 py-4">{{ el.course.name }}</td>
                <td class="px-6 py-4 space- x-4 space-y-3 text-center text-white">
                  <button
                    @click="DeleteChapter(el.id)"
                    class="py-2 px-4 bg-red-700 rounded-md md:mx-1"
                  >
                    حذف
                  </button>
                  <button
                    @click="update(el.id,el.course.id)"
                    class="py-2 px-4 rounded-md bg-neutral-700 md:mx-1"
                  >
                    تعديل
                  </button>
                  <router-link class="border text-black py-2 px-4  rounded-md" :to="`/Admin/${el.course.id}/${el.id}`">
                    اضافة دروس
                  </router-link>
                  
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
  
      <!-- ................... add new section -->
  
      <div class="container md:w-1/2 w-3/4" v-if="!hidden">
        <h1 class="md:text-3xl text-3xl text-center">{{ AddNewMood ? 'اضافة فصل جديد':"تعديل " }} </h1>
        <form @submit.prevent="submitData">
          <div class="form-control">
            <label for="name">الاسم</label>
            <input type="text" id="name" v-model.trim="updateCourseData.name" />
          </div>
          <div class="form-control">
            <label for="des">الترتيب</label>
          <input type="number" v-model.number="updateCourseData.index">
          </div>
          <div class="form-control">
            <label for="active">مفعل</label>
            <input
              type="checkbox"
              id="active"
              v-model="updateCourseData.isHidden"
            />
          </div>
  
         
          <p v-if="!formIsValid">لا تترك مدخلات فارغه</p>
          <button class="py-2 px-4 rounded-md bg-neutral-700 md:mx-1">
            ارسال
          </button>
        </form>
      </div>
    </section>
  </template>
  
  <script>
  export default {
    data() {
      return {
        hidden: true,
        isLoading: false,
        allChapters: [],
        formatedDate: "",
        error: "",
        chapterId: 0,
        courseId:0,
        updateCourseData: {
          name: "",
          index: 0,
          isHidden: true,
       
        },
        formIsValid: true,
        AddNewMood: false,
      };
    },
    methods: {
      async loadChapters() {
        this.isLoading = true;
         const courseId = this.$route.params.CourseId;
         this.courseId = +courseId;
        try {
          await this.$store.dispatch("courses/AllCourses");
          await this.$store.dispatch("courses/userchapters");

          this.allChapters = this.$store.getters["courses/CoureChapters"].filter(el => el.courseId == courseId);
          this.updateCourseData.index = this.allChapters.length + 1 ;
        } catch (e) {
          this.Error = "failed to Get Courses" || e.message;
        }
        this.isLoading = false;
      },
      async DeleteChapter(id) {
        const courseId = this.$route.params.CourseId;

        this.isLoading = true;
        try {
          await this.$store.dispatch("courses/deletechapter", id);
          await this.$store.dispatch("courses/AllCourses");
          this.allChapters = this.$store.getters["courses/CoureChapters"].filter(el => el.courseId == courseId);
          location.reload();
        } catch (e) {
          this.error = e.message || "failed to delete";
        }
        this.isLoading = false;
      },
      update(id) {
        let chapter = this.$store.getters["courses/CoureChapters"].find(el => el.id == id);
        // let chapter = this.allChapters.find((el) => el.id == id);
        this.AddNewMood = false;
        this.chapterId = id;
        this.updateCourseData = chapter;
        this.hidden = false;
      },
      addNew() {
        this.AddNewMood = true;
        this.hidden = false;
        
      },
      async submitData() {
        this.formIsValid = true;
        if (
          this.updateCourseData.name === "" ||
          this.updateCourseData.index === 0
        ) {
          this.formIsValid = false;
          return;
        }
  
        this.isLoading = true;
        let payload ;
        if(this.AddNewMood){
  
           payload = {
               
               name: this.updateCourseData.name,
               index: this.updateCourseData.index,
               isHidden: this.updateCourseData.isHidden,
               courseId:this.courseId
            };
        }else{
            
            payload = {
               id: this.chapterId,
            
            name: this.updateCourseData.name,
            index: this.updateCourseData.index,
            isHidden: this.updateCourseData.isHidden,
           courseId:     this.courseId

          };
        }
        try {
            console.log(payload);
          if (this.AddNewMood) {
            await this.$store.dispatch("courses/AddChapter", payload);
          } else {
            await this.$store.dispatch("courses/UpdateChapter", payload);
          }
  
        } catch (e) {
          this.error = e.message || "failed to update";
        }
        this.isLoading = false;
       location.reload();
      },
    },
  
    created() {
      this.loadChapters();
    },
  };
  </script>
  
  <style scoped>
  form {
    margin: 1rem;
    padding: 1rem;
  }
  
  .form-control {
    margin: 0.5rem 0;
  }
  
  label {
    font-weight: bold;
    margin-bottom: 0.5rem;
    display: block;
  }
  
  input,
  textarea {
    display: block;
    width: 100%;
    font: inherit;
    border: 1px solid #ccc;
    padding: 0.15rem;
  }
  
  input:focus,
  textarea:focus {
    border-color: #3d008d;
    background-color: #faf6ff;
    outline: none;
  }
  </style>
  