# Quincy's Graduation Design
## Author name 
Qian Xu
## Student ID
22018776
## Supervisor
Tom Keene
## Creative Computing Institute
Creative computing


# Work Record Log
## 6.20
- Project Discussion Meeting
I proposed three themes and discussed them with my mentor Tom Keene. 
1. Developing fashion assistants using artificial intelligence (Deep learning)
2. Game design: 3D adventure unity game design
3. AI brush
- Meeting record link: [https://docs.google.com/document/d/15i0V-MmF8AJ3iFOKk4Uh6DTUTmiZkJlBlL-WuoK3vLk/edit](https://docs.google.com/document/d/15i0V-MmF8AJ3iFOKk4Uh6DTUTmiZkJlBlL-WuoK3vLk/edit)


## 6.23
- Decision on the Proposal:
  After my reflection and quick research, I chose the first theme, as I believe it has a profound significance that is suitable for exploration with a rich methodology.
However, after discussing with Tom, we both agreed that the thesis should not only focus on coding but also on understanding the topic on a deeper level. 
For example: How to use digital art to draw attention to the negative consequences of people’s blind pursuit of fashion or consumption.
- Meeting record link: [https://docs.google.com/document/d/1NEXXNBVnrsQhfoUA0UfUnuwleGk8LKJCuuSIRiSSYK0/edit](https://docs.google.com/document/d/1NEXXNBVnrsQhfoUA0UfUnuwleGk8LKJCuuSIRiSSYK0/edit)

## 6.25
Developed the thesis project timeline up to 11.24. It was approved after communication with Tom.

## 6.26-6.30
Completed basic document retrieval and classification, ready to start extracting content from the literature.

## 6.30-8.1 
Completed literature extraction and the preliminary literature review section of the paper. Determined the methodology to be qualitative and quantitative analysis, initially decided on using a deep learning model as the research tool.

## 8.1-8.10
Consulted potential partners and friends for project suggestions.

## 8.10-8.20
Designed the AI model's generative effects. Initially decided to use image format, requiring training a dataset of clothing patterns to intelligently generate new clothing patterns, serving the function of using AI models as a medium to identify and recommend fashion trends to users.

## 8.20-8.30
After a horizontal comparison with similar projects, decided on using Stylegan3 as the training algorithm, an upgraded version of Stylegan2 with added recognition of rotation and translation, making the generated images more realistic than Stylegan2. The reason for choosing this algorithm is that it is more suitable for projects that generate near-real images.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/f966a04d-58fb-48a7-9d39-17de0c00f08b)

## 8.30-9.10
Completed the collection of dataset images, the preprocessing of data, and the generation of the dataset. 

### Dataset
  ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/dddbff46-d1c8-451d-bde1-c48919e40426)

### Debugging process
I also completed the code's parameter configuration, enabling the successful running of the code. Debugging process as follows.

1. When processing data with Stylegan3, the following error occurred in this code
   ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/6f6f9445-c1a4-4f1a-a41b-94e25e3d3acf)
- Located here in the error
  ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/6f63533d-3287-4c40-8fce-cabaa4a20f26)
- Therefore, debugged the code.
  ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/9209e8a8-c351-4fd7-bf75-26ab75f3d350)


2. Ninja error, showing not found, used tutorial as follows
- Link:[https://blog.csdn.net/RRRUAAA/article/details/131171809](https://blog.csdn.net/RRRUAAA/article/details/131171809)
- ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/36f46dda-aad9-4367-b143-714753c77c81)

3. To run the code quickly, data was pre-downloaded to the cache location. This depends on the network speed.
 ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/05362b07-781b-4ef7-af61-2563a44936fc) ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/4e671a91-e234-4095-b6a1-e77423905c41)

4. For the adjustment of hyperparameters, refer to the following tutorial website.
- Link:[https://github.com/NVlabs/stylegan3/blob/main/docs/configs.md](https://github.com/NVlabs/stylegan3/blob/main/docs/configs.md)
- ![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/e677cbe6-0f2b-4805-b77a-8452e1bae57f)

5. Part of training log
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/48fdf190-b35f-4f83-a00c-fecedcecb112)

## 9.11-9.15 
Started training and found that the training progress with one GPU was too slow, with a complete cycle taking 133 days. This was too high a cost for trial and error for this project, so I decided to change the training mode and train using the pre-trained models provided by the official Stylegan3.

## 9.16-9.20
- **The project training was still too slow, so I decided to rent a cloud computing server from a network agent. After consulting, I learned that the V100 quad graphics card is the fastest card I could rent at the time, but the rental cost was high. Therefore, I first rented it for 5 days to observe the trial run of the training.**
According to official documents, the estimated computation time using 8 V100 cards is 5 days.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/bdeeee63-e962-48f5-9440-f1d40cf4de53)
- **After five days of training, the model's progress reached 10%, but the effect was very poor. I think there was overfitting when training on my dataset using the pre-trained model, possibly because the model is too large and the data volume too small. After weighing the overall training time and cost, I decided to change my approach and avoid the high cost of trial and error in deep learning projects within the limited time. So I started researching new forms of expression.**

## 9.21-9.30
**The new project plan was determined to be a 3D adventure Unity game. In this case, I could use the previously discussed plan with the teacher about the second theme and make the game's theme reuse the content of the previous literature search, improving efficiency.**

## 10.1-10.15
Wrote the game outline and storyboard, determined the basic logic. At the same time, started writing the thesis.

## 10.16-10.31
Following the tutorial, completed the game's element selection and basic framework construction, with the thesis progressing simultaneously.

## 10.31-11.9
Completed the player movement code, the shop code, and the game UI production. Thesis progress 70%.
### Main code explanation
#### Start Screen
The start screen is controlled by the LoadScene code to jump to the Main game scene.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/ae34c36f-a11e-457f-9f2d-139a6850aaf9)

#### Player Movement
The player is controlled by an animator and these two codes for playermovement.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/eccca9d3-78bb-43dc-8fcb-62480c318d01)

#### Camera Controller
The camera follows the player's movement and is controlled by these two codes.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/1e828a01-1bdd-4772-bb77-5b62619a5aa0)

#### Enemy Animation
Enemies animations controlled by the code MY_enemy for movement and attack.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/821b7a18-fc85-40f9-a88b-b21a3e42cc6d)

#### Navigation
the AI's feasible path is rendered, and the blue ground represents the path the AI can take after rendering.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/1a946fb4-0644-4422-baab-d097437650ce)

#### Enemy Movement
Enemies use the code MY_enemy combined with NavmeshAgent to automatically patrol and chase the player.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/193664bb-5b46-4c12-a25b-14a1bc0deeac)


#### Coins Tag and Gem Tag
Coins are tagged with 'coin', and when the player collects a coin, it will be detected as a coin.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/29109c3c-57f9-4a08-bd40-80004716d040)

Diamonds are tagged with 'gem', and when the player collect a diamond, it will be detected as a diamond.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/fe4cee3a-d262-496f-88bc-4f6947fbea02)

#### Sound Effects
This part of the script is for detecting whether the player touches a coin or a diamond, then adds points and plays sound effects.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/00eaa007-490b-4308-a58f-a52fb81fa9ca)

#### Shop Script
The shop purchase is controlled by this script.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/256e463b-6a73-44b8-a944-d337a83b6990)

#### Shopping Node
The shopping node is controlled by this script for page turning.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/534da14a-c55b-49bf-92fe-0be4a491ddae)

#### End Screen
The end screen typewriter effect, where words appear one by one, is controlled by this.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/446a3434-f0d1-4fcb-8f1e-873ba33a11a1)


## 11.10
Held the third meeting with Tom, provided feedback on the project progress, and further defined the thesis framework.

## 11.11-11.15
Completed all game construction and recorded a video, produced related code explanation. Thesis progress 90%, formatting organized.

## 11.16-11.24
Wrapping up the project and thesis.


# Work Summary
## I. Unity Game Design Project Summary
### 1. Game Name
Treasure Journey

### 2. Video Link
[link]()

### 3. Project Code
[https://drive.google.com/drive/folders/1cJL97QdwZgfVMEeXZYG6PGwgoP4fYRwv?usp=drive_link](https://drive.google.com/drive/folders/1cJL97QdwZgfVMEeXZYG6PGwgoP4fYRwv?usp=drive_link)

### 4. Game Type
Third-person 3D game, a combination of action-adventure, survival, and collection games. Such games typically offer a rich exploration experience and challenging survival elements, appealing to players who like diverse gaming experiences.

### 5. Game Play
#### 5.1 Controls
- Control character movement with arrow keys, spacebar to jump, c key to crouch.
- Mouse movement controls camera angle changes.
- Mouse click to skip text cutscenes.

#### 5.2 Ending Trigger Conditions
- Winning condition: Unlock all items and end with health not at zero.
- Losing condition: Health <= 0.


### 6. Experience Design
Technically, we used Unity as the game development software platform, which offers powerful tools and features to create high-quality gaming experiences. During development, I first created the game scene, characters, and basic colliders based on 3D gaming fundamentals. Then controlled the camera position to follow the player and the camera angle to follow the mouse coordinates. In the game scene, I set some patrol points and added enemy characters. By writing code, we made the enemies patrol fixed routes and chase and attack the player within a certain range. To increase the game's playability and strategy, we designed two different types of loot, diamonds and gold coins, where 1 diamond = 10 gold coins, to speed up the collection process and prevent boredom while collecting gold coins. Additionally, we added successful unlock and game completion cutscenes. Players need to unlock all items to restore the cutscene and meet the completion criteria. Through these technical choices and designs, we strive to create a rich, challenging, and engaging gaming experience for players.

### 7. Game Storyboard
#### 7.1 Start main menu
<img width="483" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/ffb74934-fb3d-4d44-8415-64d18156074a">
<img width="478" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/eefd8c17-db75-4ed8-95bc-6f58a206f99d">

#### 7.2 Character Movement
Top right mini-map shows location Spacebar to jump, c key to crouch and hide footsteps
<img width="557" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/c17ac5a7-bd6e-4d9e-9311-00e18d1cb711"><img width="558" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/2b9eee6d-bff2-4034-9f44-753887d4c52b">

Movement combined with spacebar or c key for new movement methods
<img width="561" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/83c6204c-c91c-40e8-a953-6349d35d362a">

#### 7.3 Exchange Shop
Every two items unlocked unlocks text cutscenes
<img width="554" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/faf2e617-9788-44b5-ada3-872a784ec3b6"><img width="557" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/872eb1a8-fddd-47b5-97ef-95bc406b8790">

#### 7.4 Enemy Patrol
Within patrol range, players will be chased by animals
<img width="560" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/b6223d57-2eee-4796-a08b-2c115ff9ad34"><img width="554" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/661c29b6-4b80-4dff-a4b6-961e37e9888e">

#### 7.5 Ending Scene
- Ending One
  Die when attacked and health drops to 0
  <img width="554" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/061ece29-0d64-4b4b-a3b1-0240f5382da5">

- Ending Two
  Unlock all items, then Next jumps to the end screen
  <img width="555" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/c1004ea5-eff8-483e-a06e-bd7b17fd0ae6">
  <img width="554" alt="image" src="https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/92675fe6-a0f0-4203-976e-caa93b9df586">


### 8. Game Purpose
Deeply reflects and satirizes the pursuit of high-end goods in modern society and its social and psychological impacts. Players in the game play as an adventurer, aiming to collect gold coins to buy luxury goods. The game environment is set in a virtual world full of natural disasters

### 9. Work Description
- Secondary data research
- Qualitative and quantitative analysis
- Theme planning, character design
- Game code production
- Game trial feedback


## II. Deep Learning Model Training Project Summary
### Algorithm Choice
StyleGan3

### Related Tutorial
[https://www.youtube.com/watch?v=R546LYsQk5M](https://www.youtube.com/watch?v=R546LYsQk5M)

### Official Code Repository
[https://github.com/NVlabs/stylegan3](https://github.com/NVlabs/stylegan3)

### Dataset Link
[https://drive.google.com/file/d/1A7CpJQp6bW_MnOoyV1mkiQztncAm-Re5/view?usp=drive_link](https://drive.google.com/file/d/1A7CpJQp6bW_MnOoyV1mkiQztncAm-Re5/view?usp=drive_link)

I created a dataset of 1000 classic lace pattern images, using segmentation and rotation data augmentation techniques to increase the dataset size. Project Goal: To generate similar clothing style types on user-uploaded clothing images based on current fashion trends, helping fashion industry designers and users interested in clothing matching predict the fashion trends of classic brands.

### Evaluation Method
Ability to generate new lace pattern images, using accuracy model.

### Project Outcome
Due to the lack of high-performance computing, the difficulty of retraining the Stylegan3 model on my dataset was too high. The training results did not meet the requirements due to the high difference between training clothing patterns using the official pre-trained model. Therefore, it sparked my need for high-performance computing in the field of machine learning, linking to the conflict between high consumer desires and purchasing power in society.

### Project result video link
[https://youtu.be/GRL2zy0W6VQ](https://youtu.be/GRL2zy0W6VQ)
