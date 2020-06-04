Server startup:

1. find all classes
2. figure out how to route to them
3. setup a route table

make a web request

server:
1. parse route
2. find if object is routable
3. send to route
4. MVC TIME!!
 1. find controller
 2. find method (technically these two are registered in 3. on server startup)
 3. get the method executor <-- Transient vs Static
   1a. if transient, call new:
   1b. get object
   2. execute on method