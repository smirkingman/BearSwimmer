# BearSwimmer: Can Math Help You Escape a Hungry Bear?

This program solves the puzzles proposed in Quanta Magazine https://www.quantamagazine.org/can-math-help-you-escape-a-hungry-bear-20210629/

## Description

The method is a crude brute-force approach, trying combinations of parameters exhaustively.
It is writtem in VB.Net and compiled with Visual Studio 2019 https://visualstudio.microsoft.com/vs/
This is a prototype, uncommented and probably not a good example of how to program; I wrote it solely to solve the problems.

## Getting Started

### Dependencies

Runs on any version of Windows that supports .Net 5.0

### Installing

Unzip to a local directory

### Executing program
Run /executable/BearSwimmer.exe

## Authors
Maurice Calvert, maurice AT calvert DOT ch

## License

This project is licensed under the Public Domain License and like everything free, it comes without guarantees.

## Problem statements

I'm adding the puzzles' original text, just in case the article disappears:

Can Math Help You Escape a Hungry Bear?
In this month’s puzzle, math is a question of life or death.

Pradeep Mutalik
Puzzle Columnist

June 29, 2021

Once upon a time in a country far, far away, there was a champion athlete who could literally swim circles around his competition. He wished to train for the circle swimming world championship, but on account of a pandemic, he had to do so in isolation. So his country’s swimming federation constructed a perfectly circular lake in the middle of a forest where he could safely practice. Workers marked the bottom of the clear lake with concentric circles and radius measurements so he could easily tell where he was. In case you didn’t know, circle swimming is an amazing aquatic technique in which an athlete can swim as fast on any curved path as they can on a straight one. The size of the lake was carefully calibrated to the athlete’s fastest swimming speed, which was 1 unit distance over 1 time unit. The lake’s radius measured 3.5 units in length, so he took exactly 3.5 units of time to swim one full radius. To help further orient him, the center of the lake was clearly marked by a buoy.

Little did the federation know that the forest wasn’t entirely safe. One day, while practicing near the center of the lake, the swimmer noticed a bear on the shore eyeing him hungrily. He quickly swam to the center of the lake to take stock of the situation. The bear was definitely stalking him, circling the lake at a constant speed and showing no signs of giving up. But the bear wasn’t venturing into the lake, where the swimmer could have easily outdistanced it. He observed that though the bear was on the slow side, its running speed was still 3.5 times as fast as he could swim. He was getting a little tired and realized that he could not stay in the lake indefinitely. He was confident that if he managed to exit the lake ahead of the bear, he could quickly dash into the surrounding trees and evade the animal.

Think about the above scenario for a moment before reading further or trying to make detailed calculations. In what pattern should this athlete swim in order to give himself the best chance to make his escape?

Have you come up with an outline of a strategy? OK, now you can read on.

A bi-monthly puzzle celebrating the sudden insights and unexpected twists of scientific problem solving.
See all Puzzles
There is an animal that often finds itself in a somewhat similar position to the swimmer and has perfected an effective strategy for frustrating its pursuers: the common gray squirrel. A squirrel pursued by a dog always positions itself at a point diametrically opposite to its pursuer while simultaneously climbing higher into the tree, soon making good its escape. The squirrel relies on its much faster angular speed as it navigates a smaller circumference than the pursuing dog, which has to make a much larger circle far from the tree. This strategy is so effective that an astronaut uses it to evade an enemy space cruiser in Arthur C. Clarke’s Hide and Seek.

You can see how such a strategy might come in handy in the swimmer scenario. Fully resolving the problem requires detailed calculations, so let us proceed step by step with a few sets of bite-size questions. In finding the answers to these questions, you must assume that the bear will instinctively follow the strategy most advantageous to itself.

Puzzle 1
How can the swimmer apply the squirrel strategy (keeping in a direction diametrically opposite to the bear) to get into the best position to escape?
What kind of path does the swimmer trace in doing so?
How many full turns will the swimmer make before the squirrel strategy stops being of any further help?
How long does it take to reach that point?
Can the swimmer finally evade the bear?
This is a classic problem that has been explored before. It may be familiar to some readers, though we’ve changed the numbers. If you’ve gotten this far, try the next set of questions, which I don’t believe have been posed before. You can model the geometry of the situation and use analytical techniques or numerical simulations to try and find the answers.

Puzzle 2
Suppose our goal is not just to evade the bear but to escape as fast as possible (our swimmer’s arms and legs are tired, after all). Which of these strategies is most efficient, and what is the fastest escape time in each case?

Follow the squirrel strategy until it doesn’t help any longer, and then make a dash for it in the radial direction.
Follow the squirrel strategy until it doesn’t help any longer, and then make a dash for it in some other direction.
Follow the squirrel strategy for some time, and then make a dash for it in some direction.
Follow some other strategy instead of the squirrel strategy.
Puzzle 3
Suppose, on the other hand, that the athlete’s goal is to get out of the lake as far ahead of the bear as possible. Which of these strategies is now most efficient, and what is the greatest distance he can put between himself and the bear along the lake circumference?

Follow the squirrel strategy until it doesn’t help any longer, and then make a dash for it in the radial direction.
Follow the squirrel strategy until it doesn’t help any longer, and then make a dash for it in some other direction.
Follow the squirrel strategy for some time, and then make a dash for it in some direction.
Follow some other strategy instead of the squirrel strategy.
Now here are some bonus questions for those who just cannot get enough of this puzzle.

Bonus 1
Does the best strategy for puzzles 2 and 3 change if the radius of the lake is 4.5 units and the bear’s running speed is 4.5 times that of the swimmer? (The swimmer’s speed remains the same as before.)

Bonus 2
What is the highest ratio between the bear’s running speed and the swimmer’s speed that will still allow the swimmer to escape? (Assume that the radius of the lake in units is equal to this ratio, and the swimmer’s speed is unchanged.)

That’s it for this month’s Insights puzzle. I’m eager to see what kinds of solutions you come up with to these questions.

Happy figuring, and try not to go around in circles!

Editor’s note: The reader who submits the most interesting, creative or insightful solution (as judged by the columnist) in the comments section will receive a Quanta Magazine T-shirt or one of the two Quanta books, Alice and Bob Meet the Wall of Fire or The Prime Number Conspiracy (winner’s choice). And if you’d like to suggest a favorite puzzle for a future Insights column, submit it as a comment below, clearly marked “NEW PUZZLE SUGGESTION.” (It will not appear online, so solutions to the puzzle above should be submitted separately.)