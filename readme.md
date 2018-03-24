# Pluto Rover

After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Rover  to further investigate the surface...

## Things I would do next, given more time

- The implementation of obstacle detection was a bit rushed: I wrote some fairly minimal tests and then made them pass quite quickly.
I'd like to add further test coverage of obstacle detection and then refactor the code to improve readability (as well as fix any bugs
those tests might expose!)

- There are other areas of the code that could definitely stand to be refactored a bit to improve readability, or to better separate concerns
between the types involved - these are generally noted in `#TODO` comments

- I wrote all my tests against the interface of the Rover type, as I didn't (knowingly, at least!) encounter any problems that required me to break
the tests down into smaller units to examine the internals. This has the advantage of making it easier to change the internals of the Rover without
changing the tests, but if it became more complex, it might be preferable to be able to test individual units in isolation from the others. At the very
least, it might be nice to break up my single test class into different test classes for each operation of the rover