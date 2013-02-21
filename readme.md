Single Layer Neural Network
===========================
Hebbian Supervised Learning Algorithm
--------------------------------------

This is a simple single layer neural network implementation that populates using supervised learning with the Hebbian Learning algorithm.

The main use of this project is for educational purposes or to test this algorithm without having to build it from scratch.  Here are the basics of this implementation:

-  The data being represented is a 4x4 pixel "image" that is either colored in or not. (This means 16 input and output nodes for the neural network)
-  The Hebbian Learning algorithm asks that you enter in some samples of "correct" images.  It uses your inputs to populate the weights for the neural network inputs to outputs.  
-  Essentially what happens it that the code judges how likely each pixel is to be colored in based on what pixels are currently colored in.  So if it sees a pixel that is usually colored in when pixel [2,3] and pixel [2,4] are  colored in, the program will be able to guess that this pixel should be colored as well.
-  After creating test patterns, you can open up the "Execute Hebbian Learning" screen and put in images and it will "guess" the correct image you are trying to use. For example:  If you train it to recognize a square of pixels, it will fill in any missing pixels if what you enter is similar to a square.

Some of the main flaws of this algorithm:
-  Everytime you train it on an image, it unintentionally also stores the inverse of that image.  
-  If it is trained long enough, the data it has gets very "fuzzy".  This means that it may end up inventing its own images after a certain amount of time.  It may also make it more difficult for it to guess the correct image.  In some cases it will get so bad that it will give an incorrect image even when given the exact image used to train it.