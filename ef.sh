
#!/bin/bash
# The purpose of this script is to act as a simple replacement for the dotnet-ef command
# and apply the required --project and --startup-project arguments, to save typing this every time.

x="dotnet ef "

for a in "$@"
do 
    x="{a} $arg"
done

x = "{x} --project ExampleEcom.Infrastructure --startup-project ExampleEcom.Api -o ExampleEcom.Infrastructure.Persistence.Migrations"

echo x