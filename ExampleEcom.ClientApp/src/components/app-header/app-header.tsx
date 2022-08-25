import NavBar from "../nav-bar/nav-bar";
import styles from "./app-header.module.scss";

export interface AppHeaderProps {}
const AppHeader: React.FC<AppHeaderProps> = (props) => {
  return (
    <>
      <div className={styles["app-header"]}>
        <div className={styles["app-header__content"]}>
          <div className={styles["app-header__content__title"]}>
            Example Ecom
          </div>
        </div>
      </div>
      <NavBar />
    </>
  );
};
export default AppHeader;
