import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44311/api/ToDo"
});

export default {

  getAll() {
    return http.get(`/list`);
  },

  get(id) {
    return http.get(`/list/${id}`);
  },

  create(taskList) {
    return http.post('/create', taskList);
  },

  update(taskList) {
    return http.put(`/update`, taskList);
  },

  delete(id) {
    return http.delete(`/delete/${id}`);
  }
}