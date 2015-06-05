# Embedding Dll demo

This demo shows you how you can embed an existing dll in your program.

## The demo

The solution contains two projects:
- MyFramework (is the dll you want to embed in your app)
- EmbeddingDemo.Host (the app)

### MyFramework
The output of the project is sent to the root lib folder. You can verify it by right click on the project -> Properties -> Build -> Output

### EmbeddingDemo.Host
This project contains two options you can use to load an embedded dll.
To be able to code against the MyFramework, you need to add a reference to the dll. As you don't want the reference to be copied to the output folder, you need to set the "Copy Local" property to "false".


#### Option 1
Add the MyFramework.dll as an existing item to your project. In the project I added the MyFramework.dll to the folder "EmbeddedDlls" (just to keep things organized).
Next, change the "Build Action" of the dll you just added to "Embedded Resource".
The name of the dll you want to load is:
 [assembly name].[folder name].[name of the dll you want to embed].dll
In the demo this results in "EmbeddingDemo.Host.EmbeddedDlls.MyFramework.dll".

#### Option 2
Another option is to add the dll as resource. 
Right click on your project -> Properties -> Resources -> Add resource -> Add existing file.

## Additional info
You can find some tips on: [http://www.aboutmycode.com/net-framework/assemblyresolve-event-tips/](http://www.aboutmycode.com/net-framework/assemblyresolve-event-tips/ "Tips").
