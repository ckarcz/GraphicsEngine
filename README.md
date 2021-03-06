# GraphicsEngine
A windows console 3D graphics engine written in C#.

⚠️ This is a very rudimentary learning project! See inspirations below on much better implementations.

This is a learning project regarding creating the foundations of a 3D graphics engine.

**Much inspiration was taken from these guys:**
* https://github.com/interl0per/Console-Graphics
* https://github.com/Victormeriqui/Console3D

(*Though for the vast majority of things, I am writing entirely from scratch for complete learning.*)

Customized wavefront obj loading code I am currently using:
https://github.com/ChrisJansson/ObjLoader

## Features:
* Loading of 3D wavefront object models, converting to mesh representation. Models with faces containing more than 3 vertices is supported.
* Lazy rasterizer: A sequence of drawing actions are cached and only executed when final image rasterization is executed.
* Ability to draw (rasterize) points, lines, triangles, polygons, vertical & horizontal strings, axes, and meshes to buffer. 
* Mesh center vertices and bounding box can also be drawn. 
* Meshes can be rasterized as wired polygons, vertices, or as solids (tad bit buggy).
* Ability to transform rasterized objects: scaling, translation, and rotations along every axis.
* 16 bit polychromatic rendering baby! Still a bit to do for the API for the colors and such.
* Rudimentary polygon hiding algo (zbuffer). (tad bit buggy)

## To do:
* Update transformation so objects are scaled and rotated around the objects center, even for object models not centered around (0, 0, 0).
* Implement a camera (perspective projection).
* Lighting & shadows.
* Some Kernel32 Console Abstractions (coloring, etc).
* Create an asteroids game demo using the engine.

# Screenshots:

 http://gfycat.com/DigitalWhichGar
![asdfasf](https://github.com/ckarcz/GraphicsEngine/blob/master/colored_wired_woman_demo.gif)
