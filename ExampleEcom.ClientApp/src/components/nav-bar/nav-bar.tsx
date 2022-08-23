import { useContext } from "react";
import UserContext from "../../context/user-context";
import styles from "./nav-bar.module.scss";

export interface NavBarProps {}

const NavBar: React.FC<NavBarProps> = (props) => {
  const { isSiteAdmin } = useContext(UserContext);

  return (
    <div className={styles["navbar"]}>
      <div className={styles["navbar-links"]}>
        <div className={styles["navbar-links__main"]}>
          <a href="/">one</a>
          <a href="/">two</a>
          <a href="/">three</a>
        </div>
      </div>
      {isSiteAdmin() && (
        <div className={styles["navbar-links__admin"]}>
          <a href="/products/add">Add Product</a>
        </div>
      )}
    </div>
  );
};
export default NavBar;
