import { useEffect, useState } from "react";
import { User } from "../schemas/user-schemas";
import UserContext from "./user-context";

enum StoredDataType {
  User = "USER",
}

const getLocalData = <T,>(
  type: StoredDataType,
  setT: React.Dispatch<React.SetStateAction<T>>
) => {
  const localData = localStorage.getItem(type);
  if (localData) {
    setT(JSON.parse(localData) as T);
  }
};
const setLocalData = <T,>(type: StoredDataType, value: T) => {
  if (value) {
    localStorage.setItem(type, JSON.stringify(value));
  } else {
    localStorage.removeItem(type);
  }
};

const UserContextProvider: React.FC<{ children: React.ReactNode }> = ({
  children,
}) => {
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    getLocalData(StoredDataType.User, setUser);
  }, []);

  useEffect(() => {
    setLocalData(StoredDataType.User, user);
  }, [user]);

  return (
    <UserContext.Provider value={{ user, setUser }}>
      {children}
    </UserContext.Provider>
  );
};

export default UserContextProvider;
