# SVTRobo
SVT Robo
This API pulls a list of robots from "https://60c8ed887dafc90017ffbd56.mockapi.io/robots".
It accepts a set of coordinates, and finds the distance for each robot.
After that, it sorts the robot array by battery level, descending.
It returns the closest robot with the highest battery level.
If I were to move forward with it, I would add an optional parameter to indicate the minimum battery level. This would allow us to fine-tune it so we don't let a couple of battery points create long delivery times. I would also add some sort of logging to track the most used coordinates. This would allow us to set up "loiter here" areas for them to go to when they don't have anything else to do.
