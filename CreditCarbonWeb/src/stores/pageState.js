import { defineStore } from "pinia";

export const usePageStateStore = defineStore({
  id: "pageState",
  state: () => ({
    path: {},
  }),
  actions: {
    getState(path, state) {
      if (this.path[path] && this.path[path][state]) {
        return this.path[path][state];
      }
      return null;
    },
    setState(path, state, value) {
      if (!this.path[path]) {
        this.path[path] = {};
      }
      this.path[path][state] = value;
    },
  },
});
