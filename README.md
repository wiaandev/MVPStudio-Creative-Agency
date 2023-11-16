<br />

![GitHub repo size](https://img.shields.io/github/repo-size/wiaandev/MVPStudio-Creative-Agency?color=purple)
![GitHub watchers](https://img.shields.io/github/watchers/wiaandev/MVPStudio-Creative-Agency?color=white)
![GitHub language count](https://img.shields.io/github/languages/count/wiaandev/MVPStudio-Creative-Agency?color=purple)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/wiaandev/MVPStudio-Creative-Agency?color=white)

<h5 align="center" style="padding:0;margin:0;">Wiaan Duvenhage | Liam Wedge | Shanré Scheepers</h5>
<h5 align="center" style="padding:0;margin:0;">200307 | 21100218 | 21100387</h5>
<h6 align="center">DV300 | Term 3</h6>
</br>
<p align="center">

  <a href="https://github.com/wiaandev/MVPStudio-Creative-Agency">
    <img src="Images/logo.png" width="100px">
  </a>

<h3 align="center">MVP Studio</h3>

  <p align="center">
    A cross-platform desktop application where admins can manage and administrate their clients, projects and employees<br>

   <br />
   <br />
    ·
    <a href="https://github.com/wiaandev/MVPStudio-Creative-Agency/issues">Report Bug</a>
    ·
    <a href="https://github.com/wiaandev/MVPStudio-Creative-Agency/issues">Request Feature</a>
</p>
<!-- TABLE OF CONTENTS -->

## Table of Contents

- [About the Project](#about-the-project)
  - [Project Description](#project-description)
  - [Built With](#built-with)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [How to install](#how-to-install)
- [Features and Functionality](#features-and-functionality)
- [Concept Process](#concept-process)
  - [Wireframes](#wireframes)
- [Development Process](#development-process)
  - [Implementation Process](#implementation-process)
    - [Highlights](#highlights)
    - [Challenges](#challenges)
  - [Future Implementation](#peer-reviews)
- [Final Outcome](#final-outcome)
  - [Mockups](#mockups)
- [Conclusion](#conclusion)
- [License](#license)
- [Contact](#contact)
- [Acknowledgements](#acknowledgements)

<!--PROJECT DESCRIPTION-->

## About the Project

<!-- header image of project -->

![image1][image1]

### Project Description

Welcome to MVP Studio! A desktop application that runs on both MacOS and Windows where you can sign in as an admin and manage the projects, employees, clients and funds of MVP. You would be able to create projects, set deadlines and assign teams to a project and close off a month once all the projects for those months have concluded. See how MVP is doing when you visit the dashboard and get a breakdown of the current projects and the funds.

### Built With

[<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;](https://learn.microsoft.com/en-us/dotnet/csharp/)
[<img src="https://miro.medium.com/v2/resize:fit:800/format:webp/1*r9PHaS8b0YCrOnMu9tZz9g.png" width="12%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;](https://dotnet.microsoft.com/en-us/apps/maui)

### Team Roles and Responsibilities

| Member | Role | Responsibility |
| ------------- | ------------- | ------------- |
| Wiaan Duvenhage  | Team Dev Lead | Dashboard Page & Project Management Page |
| Liam Wedge  | Front-End Dev  | Login Page & Client Management Page |
| Shanré Scheepers  | Team Design Lead  | Staff Management Page & Funds Page |

<!-- GETTING STARTED -->
## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

For development, the latest version of `Visual Studio` is required. The latest version can be downloaded from [Visual Studio](https://visualstudio.microsoft.com/)
During the installation of Visual Studio make sure to select the following: `ASP.Net and web development`, `.NET Multi-platform App UI development` and `.NET desktop development`.

### Installation
Here are a couple of ways to clone this repo:

1. Visual Studio </br>

`Visual Studio` -> `File` -> `Clone Repository` -> `Git`
Enter the Git repository URL into the URL field and press the `Clone` button.
  ```sh 
  https://github.com/wiaandev/MVPStudio-Creative-Agency.git
  ``` 
2. Git Clone Repository

Run the following in the git command-line in the terminal:
  ```sh
   git clone https://github.com/wiaandev/MVPStudio-Creative-Agency.git
  ```
Open `Visual Studio` and select `File | Open` from the menu. Select `Open Project/Solution` and select the cloned directory and press `Open` button.

3. Install Dependencies </br>
When you build the project for the first time. `Nuget Package Manager` will install any project dependencies and packages required.

### Prerequisites

For the best outcome and look of the project it is advised that you run the application on the Windows as MacOS does not look the best because Visual Studio for Mac will be discontinued in August 2024. Read more about it [here](https://devblogs.microsoft.com/visualstudio/visual-studio-for-mac-retirement-announcement/)

<!-- FEATURES AND FUNCTIONALITY-->
<!-- You can add the links to all of your imagery at the bottom of the file as references -->

## Features and Functionality

<!-- note how you can use your gitHub link. Just make a path to your assets folder -->

### Login to your account

![image2][image2]
As an administrator, you can log into your account and access MVP Studio and its features.

### Dashboard Screen

![image3][image3]
Upon login, admins can have a breakdown of all the ongoing things in MVP like the list of employees, clients, the funds as well as the ongoing projects.

### Project Management Screen

![image4][image4]
Admins can view a list of the all the projects and view some of its details like the team asssigned when it starts and the client the project belongs to.

### Project Overview Screen

![image9][image9]
Clicking on the project. Admins can have an overview of the selected project, like the cost of the project, how much hours and weeks it will take to complete and a description of what the project is about.

### Clients Screen

Admins can have an overview of the current clients of MVP Studio. Admins can add or edit the clients information as well

### Staff Management Screen

Like the clients screen users can manage the staff of MVP Studio. Admins can view and edit the staff of MVP Studio as well as seeing the hourly rate which differs between designers and developers.

### Funds Management Page

Lastly admins can manage the funds of MVP Studio. Admins can see the revenue and profit of MVP Studio as well as close down the month when everything has concluded.

<!-- CONCEPT PROCESS -->
<!-- Briefly explain your concept ideation process -->
<!-- here you will add things like wireframing, data structure planning, anything that shows your process. You need to include images-->

## Concept Process

We drew significant inspiration from [Monday.com](https://monday.com), particularly admiring its color scheme and the airy feel of its light theme. MVP Studio echoes the vibe of that application, aiming for a blend of aesthetics and functionality. Our goal was to create something visually appealing yet highly functional, and we believe we've succeeded in achieving that.

### Moodboard
![image5][image5]

### Wireframes

![image6][image6]

### Entity Relational Diagram

![image8][image8]

### Sequential Chart

![image9][image7]

## Development Process

The `Development Process` is the technical implementations and functionality done for the app.

### Implementation Process

For the entirety of the project, I have used <b>.NET MAUI</b> and the entire project was built in XAML for the components and layout and C# as the code-behind.

- ```Microcharts()``` was used for the charts
- `MauiCommunityToolkit()` was also used during the project to handle pop-ups
- `Montserrat` and `Hind` were the font families used throughout the application

#### Front-End

- I used `ContentViews` to build my own custom components like cards for the projects and then used `Binding` properties to send props

- Using `<CollectionView>` I was able to loop through my data that would be viewed in a list or grid. I used this to populate for example all my list of projects in my `ProjectManagementPage.xaml` page.

##### Navigation
- Using `Shell.Current.GoToAsync()` I was able to navigate to my pages
- I used the `Shell` to build out my navbar on the left-hand side.

#### Highlights

<!-- stipulated the highlight you experienced with the project -->

- A big highlight of this project was working with C# as I was really looking forward to this language this whole year long.
- It was a big highlight to get the data from my PostgreSQL database and show it.
- Getting my layouts to work was also a very big plus

#### Challenges

<!-- stipulated the challenges you faced with the project and why you think you faced it or how you think you'll solve it (if not solved) -->

- Dealing with Mac issues when building the application was definitely very annoying! I unfortunately could not get it fixed
- Struggling to list some data in the `<Picker>` component was also very strange as it sometimes did work and other times not.

### Future Implementation


<!-- stipulate functionality and improvements that can be implemented in the future. -->

- Polishing the front-end a lot more
- Image Uploading
- Updating the project status as well as the teams
- Seeing who is part of each team

<!-- MOCKUPS -->

## Final Outcome

### Mockups

<!-- TODO Change this -->

![image2][image2]
![image3][image3]
![image4][image4]
![image5][image5]
<br>


<!-- AUTHORS -->

## Authors

- **Wiaan Duvenhage** - [Github](https://github.com/wiaandev)
- **Shanré Scheepers** - [Github](https://github.com/shanrescheepers)
- **Liam Wedge** - [Github](https://github.com/nosleeptilllambos)

<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE` for more information.\


<!-- ACKNOWLEDGEMENTS -->

## Acknowledgements

<!-- all resources that you used and Acknowledgements here -->
<!-- TODO Change this -->

- [Stack Overflow](https://stackoverflow.com/)
- [Expo Location](https://www.youtube.com/watch?v=d7G0E_9FwyE&t=396s)
- [Figma](https://www.figma.com/)
- [Lecturer](https://github.com/armandpret)
- [Mockups](https://www.freepik.com)
- [Anthony Boyd Mockups](https://www.anthonyboyd.graphics/mockups-collection/)
- [unDraw](https://undraw.co/)
- [React Native Elements](https://reactnativeelements.com/docs)

[image1]: Images/mvp-banner.png
[image2]: Images/login.png
[image3]: Images/dashboard.png
[image4]: Images/projects.png
[image5]: Images/moodboard.png
[image6]: Images/wireframes.png
[image7]: Images/seq-chart.png
[image8]: Images/erd.png
[image9]: Images/project-overview.png
[image11]: Images/mockup2.jpg
[image12]: Images/mockup3.jpg
[image13]: Images/mockup4.jpg
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/wiaan-duvenhage-95118823a/
[instagram-shield]: https://img.shields.io/badge/-Instagram-black.svg?style=flat-square&logo=instagram&colorB=555
[instagram-url]: https://www.instagram.com/wiaan.dev/
