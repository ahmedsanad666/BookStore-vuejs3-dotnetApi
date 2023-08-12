<template>
  <section class="space-y-6 md:w-1/2 w-3/4 rounded-md bg-[#ccc]" v-if="showD">
    <Teleport to="body">
      <div class="overlay" @click="$emit('TryClose')"></div>
    </Teleport>
    <!-- question -->

    <div v-if="currentMood === 'quiz'">
      <div class="h-full w-[90%] space-y-6 m-auto py-6">
        <div class="bg-mianColor py-7 shadow-lg px-5 rounded-xl mx-auto">
          <p class="text-center max-w-xl mx-auto">
            {{ currentQ.questionText }}
          </p>
        </div>
        <div>
          <ul class="space-y-4">
            <li
              class="bg-mianColor rounded-lg shadow-md py-2 px-10 tracking-wide hover:bg-slate-400"
              v-for="(el, key) in currentQ.choices"
              :key="key"
              ref="myli"
              @click="checkAns(key)"
            >
              <span class="flex justify-center items-center">{{ key }}</span>

              {{ el }}
            </li>
          </ul>
        </div>
        <div class="controller">
          <button @click="next" class="py-2 px-3 rounded-md bg-primary-green">
            التالى
          </button>
        </div>
      </div>
    </div>
    <div v-else-if="currentMood === 'win'">
    <h1 class="text-center my-4 py-4 text-3xl">you win</h1>
</div>
<div v-else>
        <h1 class="text-center my-4 py-4 text-3xl">you failed</h1>
    
    </div>
  </section>
</template>

<script>
export default {
  props: {
    showD: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      currentMood: "quiz",
      isRightAns: false,
      showAns: false,
      Questions: [],
      questionCounter: 0,
      currentQ: [],
      bookId: 0,
      currentChoice: 0,
      isLoading: false,
      rightAnsCount: 0,
    };
  },

  methods: {
    next() {
      if (this.questionCounter >= this.Questions.length - 1) {
        return;
      }
      let li = this.$refs.myli;
      li.forEach((el) => {
        el.classList.remove("wrong");
        el.classList.remove("right");
      });
      this.questionCounter++;
      this.loadCurrentQ();
    },
    async loadData(id) {
      this.bookId = id;
      this.isLoading = true;

      try {
        await this.$store.dispatch("book/getBookQuestions");

        const allQuestions = this.$store.getters["book/bookQuesions"];

        const bookQ = allQuestions.filter((e) => e.bookId === this.bookId);

        this.Questions = bookQ;
        this.loadCurrentQ();
      } catch (e) {
        this.Error = "failed to Get Courses" || e.message;
      }
      this.isLoading = false;
    },
    loadCurrentQ() {
      this.currentQ = this.Questions[this.questionCounter];
    },

    checkAns(key) {
      this.currentChoice = key;
      const choice = this.currentChoice + 1;
      const rithAns = this.currentQ.answer;
      let li = this.$refs.myli;
      let lastQuestion =
        this.questionCounter == this.Questions.length - 1 ? true : false;

      console.log(this.Questions.length);
      if (choice == rithAns) {
        this.rightAnsCount++;
        this.isRightAns = true;
        li[key].classList.add("right");
      } else {
        this.isRightAns = false;
        li.forEach((el) => {
          el.classList.add("wrong");
        });
        li[rithAns - 1].classList.add("right");
        li[rithAns - 1].classList.remove("wrong");
      }

      if (lastQuestion) {
        if (this.rightAnsCount == this.Questions.length) {
          this.currentMood = "win";
        } else {
          this.currentMood = "lose";
        }
      }
    },
  },
};
</script>

<style lang="scss" scoped>
li.checked {
  background: rgb(148 163 184);
}

li.right {
  background: green;
}
li.wrong {
  background: red;
}
li {
  cursor: pointer;
  transition: 0.3s linear;
  position: relative;

  span {
    position: absolute;
    background: #2c3e50;
    top: 0;
    left: 0;
    height: 100%;
    padding: 0.5rem;
    color: white;
    font-weight: 500;
    border-top-left-radius: 7px;
    border-bottom-left-radius: 7px;
  }
}
section {
  height: 80vh;
  position: absolute;
  z-index: 99;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
.overlay {
  position: absolute;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.8);
  top: 0;
  left: 0;
}
</style>
