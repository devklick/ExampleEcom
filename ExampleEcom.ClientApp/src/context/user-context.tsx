import { createContext } from "react";
import { User } from "../schemas/user-schemas";

interface UserContextData {
  user: User | null;
  setUser: (user: User) => void;
  isSiteAdmin: () => boolean;
}

const defaultUserContextData: UserContextData = {
  user: null,
  setUser: () => null,
  isSiteAdmin: () => false,
};

const UserContext = createContext<UserContextData>(defaultUserContextData);

export default UserContext;
