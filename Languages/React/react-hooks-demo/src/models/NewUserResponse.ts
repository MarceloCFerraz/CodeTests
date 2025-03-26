import type { User } from "./User";

export type NewUserResponse = {
	results: User[];
	info: Info;
};

export type Info = {
	seed: string;
	results: number;
	page: number;
	version: string;
};
