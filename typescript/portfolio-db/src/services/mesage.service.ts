import { AppDataSource } from "../data-source";
import { Portfolio } from "../entity/Message";
const msgRepository = AppDataSource.getRepository(Portfolio);

export const registerMessage = async (
  fullName: string,
  email: string,
  message: string
) => {
  const msg = new Portfolio();
  msg.fullName = fullName;
  msg.email = email;
  msg.message = message;
  await msgRepository.save(msg);
};
