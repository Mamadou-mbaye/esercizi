import { actors } from "../models/db.js";
export const createActor = (firstName, lastName, birthDate, rolePlaying) => {
  return actors.create({
    firstName,
    lastName,
    birthDate,
    rolePlaying,
  });
};
export const getActor = (id) => {
  return actors.findOne({ where: { id } });
};
export const updateActor = (id, newRolePlaying) => {
  return actors.update({ rolePlaying: newRolePlaying }, { where: { id } });
};
export const deleteActor = (id) => {
  return actors.destroy({ where: { id } });
};
