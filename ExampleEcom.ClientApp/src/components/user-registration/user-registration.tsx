import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { createUserRequestSchema } from "../../schemas/user-schemas";

export interface UserRegistrationProps {}

const UserRegistration: React.FC<UserRegistrationProps> = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(createUserRequestSchema),
  });

  return (
    <div>
      <h1>User Registration</h1>
      <form onSubmit={handleSubmit((d) => console.log(d))}>
        <input
          {...register("firstName")}
          aria-invalid={errors.firstName ? "true" : "false"}
        />
        {errors.firstName?.message && (
          <p>{errors.firstName?.message?.toString()}</p>
        )}

        <input
          {...register("lastName")}
          aria-invalid={errors.lastName ? "true" : "false"}
        />
        {errors.lastName?.message && (
          <p>{errors.lastName?.message?.toString()}</p>
        )}

        <input
          {...register("userName")}
          aria-invalid={errors.userName ? "true" : "false"}
        />
        {errors.userName?.message && (
          <p>{errors.userName?.message?.toString()}</p>
        )}

        <input
          type={"email"}
          {...register("email")}
          aria-invalid={errors.email ? "true" : "false"}
        />
        {errors.email?.message && <p>{errors.email?.message?.toString()}</p>}

        <input
          type={"password"}
          {...register("password")}
          aria-invalid={errors.password ? "true" : "false"}
        />
        {errors.password?.message && (
          <p>{errors.password?.message?.toString()}</p>
        )}

        <input type="submit" />
      </form>
    </div>
  );
};

export default UserRegistration;
