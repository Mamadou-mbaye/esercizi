import { Documents } from "../models/db.js";
export const createDocument = (author, title, description) => {
  return Documents.create({ author, title, description });
};
export const getDocument = (id) => {
  return Documents.findOne({ where: { id } });
};
export const updateDocument = (id, newAuthor, newTitle, newDescription) => {
  return Documents.update(
    { author: newAuthor, title: newTitle, description: newDescription },
    { where: { id } }
  );
};
export const deleteDocument = (id) => {
  return Documents.destroy({ where: { id } });
};
