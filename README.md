# Zerosum Case
## Info

Hello, I've created the Zerosum case as regarding to case properties. It was quite enjoyable for me since you provided only the basics and I am be able to improve gameplay as I want. It feels like its quite Rogue-lite game where we can improve our character and defeat end-game bosses. Even if we cant defeat boss, we still pass the level & upgrade our character & gain some gold.


**You can start playing from GameScene. I've used 2020.3.8f Unity version which is the version of the case project that you provided.**

I want to explain some features in game to more easily search in Project. 

## Features

- I'vecreated Level Prefab system that we can easily spawn level prefabs. Since its a hyper-casual. I find this useful.
- I've created LevelCreator script that helps me to create platforms by calculating length of template plaftorm. It also includes collactables & obstacles to spawn easily. I think that was the easiest & fastest way for me to create levels. It's not perfect but still worth using. You can find in Level Prefabs in LevelCreator game object.
- As we cant spend stacks, I created and End-Game boss where we can hit him by tapping screen. Boss health is upgraded in every level-change. Since i have 2 input system, I used new input system. 
- As we have game boss now, I have the capacity of spending stacks (when attacking boss, we spend stacks that we gathered.) & capacity of upgrading our player like start stack size & damage & attack rate. As we gain gold, we can upgrade our player.
- Since we need to save our values, I used PlayerPrefs to save some little data for the sake of Hyper-casual game. For larger scale projects, I would create JSON save system.
- When our character gathers stacks, character run animation blends between 0-1 (CurrentStack / MaxStack)
- I've created character state machine system where we can easily handle Pre-Game, InGame, Boss-Stage & end game. 
- For particles & gold increase UI at the end, I used Object Pooling System.

## What I would Add Later
I would add;
- more upgrades & random 3 upgrade on first screen, 
- boss mechanics, 
- obstacles with more mechanic ,
- more visual improvement, 
- shop system for our character like buying axe
- and more...


I hope you enjoy the game too! :)

