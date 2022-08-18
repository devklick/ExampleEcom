import styles from "./nav-bar.module.scss";

export interface NavBarProps {}

const NavBar: React.FC<NavBarProps> = (props) => {
  return (
    <div className={styles["navbar"]}>
      <div className={styles["navbar-links"]}>
        <a href="/">one</a>
        <a href="/">two</a>
        <a href="/">three</a>
      </div>
    </div>
  );
};
export default NavBar;
