pwd

basename $(pwd)
mydir="$(basename $PWD)"
mkdir ${mydir}
dotnet new sln
cd ${mydir}

dotnet new mvc
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer 
mkdir Models
cd Models
touch Product.cs
cat << EOF >> Product.cs
namespace ${mydir}.Models
{
    public class Product
	{
		public int ProductId {get; set;}
	}
}
EOF
touch Category.cs
cat << EOF >> Category.cs
namespace ${mydir}.Models
{
    public class Category
	{
		public int CategoryId {get; set;}
		public string CategoryName {get; set;}
		public string Description {get; set;}
	}
}
EOF
cd ..
cd ..
dotnet sln  add  ${mydir}/${mydir}.csproj
