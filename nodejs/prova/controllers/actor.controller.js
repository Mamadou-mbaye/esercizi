import {
  createActor,
  getActor,
  updateActor,
  deleteActor,
} from "../services/actor.service.js";
export const createActorController = async (req, res) => {
  const actor = await createActor(
    req.body.firstName,
    req.body.lastName,
    req.body.birthDate,
    req.body.rolePlaying
  );
  res.send({ message: "actor created", actor });
};
export const getActorController = async (req, res) => {
  const id = req.params.id;
  const actor = await getActor(Number(id));
  if (actor) {
    res.send({ message: "actor retrieved", actor });
  } else {
    res.status(404).send({ message: "actor not found" });
  }
};
export const updateActorController = async (req, res) => {
  const id = req.params.id;
  const rolePlay = req.body.newRolePlaying;
  const [actor] = await updateActor(id, rolePlay);
  if (actor != 0) res.send({ message: "actor updated", actor });
  else {
    res.status(404).send({ message: "actor not found" });
  }
};
export const deleteActorController = async (req, res) => {
  const id = req.params.id;
  const actor = await deleteActor(Number(id));
  if (actor) res.send({ message: "actor deleted", actor });
  else res.status(404).send({ message: "actor not found" });
};
