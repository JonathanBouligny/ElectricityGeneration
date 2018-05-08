# CS 4331/5331 Project 3 Proposal
### _"Electricity Generation from Natural resources"_

## Team Members:
1. Amitsingh Paredeshi
2. Jonatha Bouligny
3. Prerit Datta

### Aim of the Project
To educate children how electricity is generated from natural sources such as wind, solar power and a water turbine.


### Project Description
This project was desined in **Unity3d** and is targeted platform is a Windows PC app _(It can be ported to other OS by changing the build-settings)_. The project has 3 simulations of **_water turbine_**, **_solar panel_** and a **_wind turbine_**. Each of these simulations can be explored in any order to learn more about how they functions in the real world. The simulation allows the player to explore the scene via the _arrow keys_ and certain interactions requires clicking using mouse buttons. The interactions are displayed on the screen as user interacts with different parts of simulations as described above.


### 1. Water Turbine/Dam
The Water turbine shows various information about dams in the United States and allows the user to interact with the turbine to observe generated power. 

This is how the Dam looks like the app:

![Water_turbine_view2](/Screenshots/Dam1.png)

User is given instructions on how to navigate around the simulations as shown here:

![Water_turbine_view1](/Screenshots/Dam2.png)


The Water turbine simulation provides various information such as how power is calculated, how much power this dam generates, and how big the dam is. The user gets a chance to change the flow, turn the dam on and off, and find the information about the dam based on states by selecting it from a drop down menu, as shown the below:

![Water_turbine_view3](/Screenshots/Dam3.png)


#### Models used in the Scene:
1. https://sketchfab.com/models/8ebf72d69c53421fa028f5f218eacc89#
2. https://sketchfab.com/models/df8efdcb297049e09a20f2030bf6cf4f
3. https://3dwarehouse.sketchup.com/model/78cc2f590f41c50242471a633f328705/Power-Transformer-30-40-50-MVA-Tirathai
4. https://3dwarehouse.sketchup.com/model/edf288c16aa9797a4d423544e7c5cb27/Lattice-Steel-Guyed-Electric-tower-500kv
5. https://3dwarehouse.sketchup.com/model/7f7e2c047cb684a47e3486caff50555e/dirt-road-with-hill


### 2. Solar Panel
This simulations aims to explain how solar energy gets converted into electrical energy. The image below describes how the solar panel looks like in the simulation:

![solar_view1](/Screenshots/Solar2.png)

The instructions on how to navigate the simulation are displayed on screen such as below:

![solar_view2](/Screenshots/Solar1.png)


This simulation also explains different parts and devices needed to generate, store and transfer electricity via the panel. This simulation uses  **Restful API** provdided by **[NREL](https://developer.nrel.gov/docs/solar/) (national laboratory of the U.S. Department of Energy)** which shows the real time statistics regarding how much energry is being produced in USA using photovoltaic cell and how many units of installations are currently working accross United States. An example is shown below:

![solar_view3](/Screenshots/Solar3.png)


_**Photovoltaic**_ refers to the process of turning the energy of the Sun directly into electrical current through the use of photovoltaic cells. Photovoltaic technology is relatively new; as a viable energy source, it is less than _50 years old_. However, it has great potential for the future. As a source of energy, sunlight is free, its supplies are unlimited and it is available in the majority of areas of the world.



### 3. Wind Turbine
This simulation explains the various parts that constitute a Wind Turbine and allows the user to interact with various parameters of a wind turbine size and see the correspondinding effect on electrcity generated. The wind turbine is shown below:

![wind_view1](/Screenshots/Wind1.png)


The entire model of the turbine and the internals of the wind turbine (shown below) was created from scatch in Unity, [blender](https://www.blender.org/) , and [ProBuilder](https://assetstore.unity.com/packages/tools/modeling/probuilder-111418).

The internals (source: https://www.saveonenergy.com/how-wind-turbines-work/) of the Wind turbine, a user get to see the individual parts and their use in the simulation. 

![wind_view2](/Screenshots/Wind2.png)

After, the user has explored all the parts of the turbine, he/she can change the various parameters of the wind mill such as _efficiency_, _blade diameter_ and _wind velocity_ to the see the corresponding effect on electricity generated:

![wind_view3](/Screenshots/Wind3.png)

The data for efficiency, diameter and velocity is based on actual scietific data used to design the wind turbines in the real-world.

Max **Efficiency** for turbine can be **59.26%** due to laws of physics. This is known as **Betz limit** explained [here](http://www.wind-power-program.com/turbine_characteristics.htm) and [here](http://datagenetics.com/blog/june12017/index.html), after the scientist who discovered this phenomena. Most turbines are able to have efficiency of 0.30(30%) to 0.45 (45%) as explained [here](http://www.ewea.org/wind-energy-basics/faq/) and [here](https://www.wind-watch.org/faq-output.php).

The **diameter** of commercially availble wind turbines vary between 31m to 47m roughly. As mentioned on [this](http://www.aweo.org/windmodels.html) page.

Finally, the **velocity** of the wind also varies throughout the day. The turbines are designed to function at certain wind speed to generate electricity. These limits are described on [this](http://www.wind-power-program.com/turbine_characteristics.htm) page and the actual values have been used in the simulation. At very high or ver low speed the turbine stops rotating in the simulation. This can be adjusted by using '+' and '-' buttons in the simulation.

The formular to calculate the _**Power Generated**_ uses the values above and can be found on [this](https://www.engineeringtoolbox.com/wind-power-d_1214.html) and [this](https://www.raeng.org.uk/publications/other/23-wind-turbine) page.
