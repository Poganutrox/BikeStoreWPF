# Program Design (Modern Interface)

## Description

For this project, we are using the so-called **modern style**. This style dispenses with the top menus to enable a sidebar on the left side with different options. This behavior is very similar to what occurs on mobile devices.

## Dashboard

In the *dashboard*, a series of data related to the system state is displayed. The data is automatically updated based on a parameter that will be introduced in a menu option. The data to be displayed includes:
- Total number of Orders by the user who has logged in during the last month.
- Total number of Products with less than 10 units in Stock.
- Amount of orders placed today by the logged-in user.
- Display graphs that are described in more detail in the graphics section.
  
![image](https://github.com/Poganutrox/BikeStoreWPF/assets/63597815/cafc65a1-265c-4188-9bb1-f79920af2258)


## Graphics

This option is integrated within the main form.
- **Total number of orders per staff:** Total number of orders for each staff member. Chart format: columns.
- **Total number of products by category:** Number of products for each category. Chart format: pie.

An external library is used for this: [lvcharts](https://lvcharts.net/)

## Project Requirements

- Implement the sidebar menu in WPF with animations for expanding and collapsing.
- Visually mark the selected menu option.
- Integrate a *dashboard* with automatic data updates.
- Display specific charts using an external library.
