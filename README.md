# About the project
This is an example MAUI application I tried to use some features to improve my knowledge.

On this project, we will have a lot of performance stuff to keep our infinite scroll beautiful we will also have custom controls, animations, popups, dependency injection, extensions, unit tests etc.

#### Refit
I've used this library is used to facilitate my life with API communication is easily to use and customize.
[CHECK HERE](https://github.com/reactiveui/refit)

#### MAUI Toolkit
I've used this library to create popups and make toasts, but you can use that for a lot of cool things.
[CHECK HERE](https://learn.microsoft.com/pt-br/dotnet/communitytoolkit/maui/)

#### FFImageLoading for MAUI
This library help us to download images from url with progress and placeholder images, but the best thing that it does is caching image it can improve a lot of performance you don't need to keep downloading the stuff from websites all of the time or converting the url to Uri or some Image class to use in XAML e.g.
[CHECK HERE](https://github.com/Redth/FFImageLoading.Compat)

#### CompiledBindings
This library help us with Binding that give us a lot of performance when we need to create views with data, basically the x:Bind will be convert to C# so we won a lot of performance and we can debug the compiled layout too it will helps a lot to do some 'layout troubleshooting'.
[CHECK HERE](https://github.com/levitali/CompiledBindings)

Still about performance, I used compressedLayout too, basically it will remove the events and other things from "ViewGroup" e.g. StackLayout, ContentView... If you only use this ViewGroup to create some design that will be a greater performance assistant for you.
[MORE ABOUT](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/layout-compression)

#### ConfigureAwait(false)
This task extension helps a lot with deadlocks or bad performances when the topic is Thread, that will say to your system "don't do this job in this thread so it will remove your heavy job from MainThread or an used Thread and send to another, it's great when your task is HEAVY or to remove tasks from MainThread.
[MORE ABOUT](https://medium.com/bynder-tech/c-why-you-should-use-configureawait-false-in-your-library-code-d7837dce3d7f)

#### Nullable
On this project I tried to use nullable feature for knowledgement. I liked, we can say to another dev or ourselfs that the variable or the response of some method can be null, so you can prepare the try catch or the treatment for that.
[CHECK HERE](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/nullable-reference-types)

#### Build Config Types
You can use Api or Mock type to run this project.
The difference is Api build will get the daily feed list from the internet and the Mock will get from the assets.
