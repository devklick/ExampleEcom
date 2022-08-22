import { createContext } from "react";
import { User } from "../schemas/user-schemas";

interface UserContextData {
  user: User | null;
  setUser: (user: User) => void;
}

const defaultUserContextData: UserContextData = {
  user: null,
  setUser: () => {},
};

const UserContext = createContext<UserContextData>(defaultUserContextData);

export default UserContext;
