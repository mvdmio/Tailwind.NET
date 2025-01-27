# mvdmio.Tailwind.NET
This package makes it possible to use [TailwindCSS](https://tailwindcss.com) in your .NET project without any external dependency.

It uses the [Tailwind Standalone CLI](https://tailwindcss.com/blog/standalone-cli) to make this possible.

## Dependencies
You must have nodejs installed on your system to use this package. You can download it from [https://nodejs.org](https://nodejs.org).

## Usage
After installation, the NuGet package will automatically build the tailwind input file on every build. It will minify the output file when in Release mode.

### Install the NuGet package
```
dotnet add package mvdmio.Tailwind.NET
```

This does the following:
1. Creates a `<root>/Tailwind` folder with the following files:
	1. `tailwind.input.css` with the basics to get tailwind running.
2. Adds build targets to your `.csproj` that automatically build the TailwindCSS input file

### Tailwind Functionality
More information about Tailwind Functions & Directives: [https://tailwindcss.com/docs/functions-and-directives](https://tailwindcss.com/docs/functions-and-directives).

#### Layers
Tailwind recommends using layers like so:
```css
# /tailwind/tailwind.input.css
@import 'tailwindcss';

@layer base {
  # Your base module additions
}

@layer components {
  # Your components module additions
}

@layer utilities {
  # Your utilities module additions
}
```

#### Import
You can use `@import` to import different files like so:
```
# /tailwind/tailwind.input.css
@import 'tailwindcss';

@import './some-other-file.css'
```

```
# /tailwind/some-other-file.css

.select2-dropdown {
  @apply rounded-b-lg shadow-md;
}
.select2-search {
  @apply border border-gray-300 rounded;
}
.select2-results__group {
  @apply text-lg font-bold text-gray-900;
}
/* ... */
```

## Customization

### Customizing file locations
You can change the input and output file paths by adding the following properties in your `.csproj`:
```xml
<PropertyGroup>
  <TailwindInputFile>path/to/your/input/file.css</TailwindInputFile>
  <TailwindOutputFile>path/to/your/output/file.css</TailwindOutputFile>
</PropertyGroup>
```

The defaults for these properties are:
```xml
<PropertyGroup>
  <TailwindInputFile>tailwind/tailwind.input.css</TailwindInputFile>
  <TailwindOutputFile>wwwroot/tailwind.output.css</TailwindOutputFile>
</PropertyGroup>
```

### Override the build binary
You can override the binary used in the tailwind command:
```xml
<PropertyGroup>
  <TailwindBinaryFile>tailwindcss-linux-arm64</TailwindBinaryFile>
</PropertyGroup>
```

See the 'lib/tools' folder in this project for the binaries that can be used.

By default, the build tries to select the correct binary based on the `OS` and `Platform` properties of MSBuild.

### Disable default files copy action
The library copies default file (`tailwind/tailwind.input.css`) to your project. To disable this, add the following property:
```xml
<PropertyGroup>
  <TailwindCopyDefaultFiles>false</TailwindCopyDefaultFiles>
</PropertyGroup>
```

### Tailwind Watch
The package contains a task for running `tailwind --watch` in a separate window. To do so, open a terminal in the folder of your project, and run the following command. Note that you need to have [Visual Studio Build tools](https://visualstudio.microsoft.com/downloads/?q=build+tools#build-tools-for-visual-studio-2022) installed for this command to work.
```
msbuild /t:WatchTailwind
--or--
dotnet msbuild /t:WatchTailwind
```

Of course you can also install Tailwind using NPM and use the following command. This will **not** use this package to build your tailwind.
```
npx tailwind -i tailwind/tailwind.input.css -o wwwroot/tailwind.output.css --watch
```

# Contact
For issues with the package, please create a new issue on GitHub. Pull requests are also welcome.

For anything else, please contact me at [michiel@mvdm.io](mailto:michiel@mvdm.io).