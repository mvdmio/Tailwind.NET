# mvdmio.Tailwind.NET
This package makes it possible to use [TailwindCSS](https://tailwindcss.com) in your .NET project without any external dependency.

It uses the [Tailwind Standalone CLI](https://tailwindcss.com/blog/standalone-cli) to make this possible.

## Usage

1. Install the NuGet package
```
dotnet add package mvdmio.Tailwind.NET
```

This does the following:
  1. Creates a `tailwind.config.js` in the root of your project with some default configuration.
  2. Creates a `tailwind.input.css` file in the `<root>/tailwind/` folder
  3. Adds build targets to your `.csproj` that automatically build the TailwindCSS input file

## Customizing the input and output files
You can change the input and output file paths by adding the following properties in your `.csproj`:
```
<PropertyGroup>
	<TailwindInputFile>path/to/your/input/file.css</TailwindInputFile>
	<TailwindOutputFile>path/to/your/output/file.css</TailwindOutputFile>
</PropertyGroup>
```

