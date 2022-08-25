import * as React from "react";
import styles from "./content-container.module.scss";

export interface ContentContainerProps {
  width: "regular" | "small" | "large";
  children: React.ReactNode;
}
const ContentContainer: React.FC<ContentContainerProps> = ({
  children,
  width,
}) => {
  return <div className={styles[`content-container-${width}`]}>{children}</div>;
};
export default ContentContainer;
