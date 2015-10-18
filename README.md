# GraphicsEngine
A 16 bit windows console 3D graphics engine and framework written in C#.

This is a learning project regarding creating the foundations of a 3D graphics engine.

**Much inspiration was taken from these guys:**
* https://github.com/interl0per/Console-Graphics
* https://github.com/Victormeriqui/Console3D

(*Though I am writing entirely from scratch.*)

Customized wavefront obj loading code I am currently using:
https://github.com/ChrisJansson/ObjLoader

## Features:
* Loading of 3D wavefront object models, converting to mesh representation. Models with faces containing more than 3 vertices is supported.
* For now, a simple monochromatic screen rendering.
* Lazy rasterizer: A sequence of drawing actions are cached and only executed when final image rasterization is executed.
* Ability to draw (rasterize) points, lines, triangles, polygons, vertical & horizontal strings, axes, and meshes to buffer. Mesh center vertices and bounding box can also be drawn. Meshes can be rasterized as wired polygons, or vertices.
* Ability to transform rasterized objects: scaling, translation, and rotations along every axis.

## To do:
* Update transformation so objects are scaled and rotated around the objects center, even for object models not centered around (0, 0, 0).
* Implement a polygon filling algorithm (solid rasterization).
* Fix the Win32 (pinvoke) 16-bit polychromatic console class so that multiple colors can be used.
* Implement a camera (perspective projection).
* Implement a hiding algorithm so that when multiple objects are rasterized, proper hiding of objects occurs from the camera's perspective. (ZBuffer algo, etc)

# Screenshots:
![alt tag](http://giant.gfycat.com/WeepyGloriousAnaconda.gif)

![alt tag](http://i.imgur.com/ScSQBY8.png)

![alt tag](http://i.imgur.com/UKBWv02.png)

![alt tag](http://i.imgur.com/JYhHDZI.png)

![alt tag](http://i.imgur.com/9IdgJmj.png)
