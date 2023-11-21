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
- The project training was still too slow, so I decided to rent a cloud computing server from a network agent. After consulting, I learned that the V100 quad graphics card is the fastest card I could rent at the time, but the rental cost was high. Therefore, I first rented it for 5 days to observe the trial run of the training.
According to official documents, the estimated computation time using 8 V100 cards is 5 days.
![image](https://github.com/Quincy816/Quincy-Graduation-Design/assets/115622644/bdeeee63-e962-48f5-9440-f1d40cf4de53)
- After five days of training, the model's progress reached 10%, but the effect was very poor. I think there was overfitting when training on my dataset using the pre-trained model, possibly because the model is too large and the data volume too small. After weighing the overall training time and cost, I decided to change my approach and avoid the high cost of trial and error in deep learning projects within the limited time. So I started researching new forms of expression.

## 9.21-9.30
The new project plan was determined to be a 3D adventure Unity game. In this case, I could use the previously discussed plan with the teacher about the second theme and make the game's theme reuse the content of the previous literature search, improving efficiency.

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
