# Simulator training

I have been testing if it is possible to train a model inside the simulator and use that model in real life, and here are my results for different scenarios.

## Simulator environment 1: Outdoor area

 The first environment is the outdoor area outside our office where I can test the donkey car. So I have recreated the environment and put it into the simulator.

**Real life location:**

<img src="assets/img_001.jpeg" width="650" height="350" />

**Simulator environment:**

<img src="assets/img_002.png" width="650" height="350" />

Being a outdoor environment, the sun will be constantly moving, so in order to match the simulator lighting with real world lighting, I have make a simple day night cycle effect which allows me to adjust the sun's angle before testing.

<img src="assets/vid_001.gif" width="650" height="350" />

## Training process

As the goal is to see if a model trained with the simulator can be used in real life, I decided to create a simple model where the car would drive in a rectangle shape and turn left in each corners. I am using manual drive mode and collected ~20000 images inside the simulator, then train it in Google Colab.

### Version 1 (static lighting)

In this version, I tried to match the simulator lighting to the real world lighting (cloudy)

**Simulator result:**

<img src="assets/vid_002.gif">


**Simulator result with salient map:**

<img src="assets/vid_003.gif">

**Real life result:**

<iframe width="560" height="315" src="https://www.youtube.com/embed/vS7hcChmkJw" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

The car seems to be able to detect features from the simulator in real life and is able to turn left when close to the blue wall, however, for the second turn, the result are less ideal, instead of a sharp left turn, the car performs a gentle left turn, making it go off the intended paths and crashes at the end.

### Version 2 (dynamic lighting)

Besides training using a static lighting, I also tried to test if its possible to create a more universal model where it can adopt to different lighting conditions. So I trained another model where the lighting are constantly changing at a high speed. I am using manual drive mode and collected ~20000 images also.

**Simulator result:**

<img src="assets/vid_002.gif">

**Simulator result with salient map:**

<img src="assets/vid_003.gif">

**Real life result:**

<iframe width="560" height="315" src="https://www.youtube.com/embed/vS7hcChmkJw" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

The car seems to be able to detect features from the simulator in real life and is able to turn left when close to the blue wall, however, for the second turn, the result are less ideal, instead of a sharp left turn, the car performs a gentle left turn, making it go off the intended paths and crashes at the end.