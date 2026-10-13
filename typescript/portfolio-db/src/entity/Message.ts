import { Entity, PrimaryGeneratedColumn, Column } from "typeorm";

@Entity()
export class Portfolio {
  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  fullName: string;

  @Column()
  email: string;

  @Column()
  message: string;
}
