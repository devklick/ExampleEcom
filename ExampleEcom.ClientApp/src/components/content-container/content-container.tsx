import * as React from "react";
import styles from "./content-container.module.scss";

export interface ContentContainerProps {
  children: React.ReactNode;
}
const ContentContainer: React.FC<ContentContainerProps> = ({ children }) => {
  return <div className={styles["content-container-regular"]}>{children}</div>;
};
export default ContentContainer;
