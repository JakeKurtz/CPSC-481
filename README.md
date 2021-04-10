# CPSC 481 - Final Project Vertical Prototype

Submitted by Group 14

- Afrah Ahmed
- Carmen Khuu
- Jake Kurtz
- Michael Le Manne


## Installation

Download or pull the code from the repository, and open 
```CPSC-481.csproj``` in Visual Studio.

## Usage

To run the program, select "Start" in the Visual Studio toolbar.

No necessary data input is required for the application to work. The main navigation consists of:
- Food menu
- Drink menu
- Order page
- Help page

Notes:
- To make selections, use the mouse left click.
- To scroll up/down, use your mouse scroll wheel or trackpad scroll.

### Food Menu
Select **Food** to navigate to the food menu. This consists of 4 subpages: Specials, Appetizers, Main and Sides. Each button on the top of the screen swaps between the subpages.

- The filter button can be selected to filter out foods by certain allergies, or used to filter menu items by diet. To use it, select the filter button, check the desired allergies or diets and click "OK". The Page will update with the appropriate results.
- Items with a star in the bottom right corner are recommendations by the restaurant.
- To scroll up/down the menu, use your mouse or touchpad scroll.
- To add a food to your order, select an item from the menu.
- If there is a dropdown menu under **Options**, expand and select an option. Options consist of mandatory fields. If an Option is left blank, selecting the "Add to Order" button will remind you to select from the options.
- If applicable, select **Addons**, which are optional fields.
- A message to the kitchen can be entered under **Special Requests** via keyboard. This is an optional field.
- Select the "Add to Order" button to add item to your order.

Once the desired options and addons are selected, select "Add to Order". The price in the button should reflect your options and addons.

Repeat the above bullet points for as many food menu items as desired.

### Drinks Menu

Select **Drinks** to navigate to the drink menu. This consists of 4 subpages: Beer, Wine, Cocktails and Non-Alcoholic. Each button on the top of the screen swaps between the subpages.

The drink menu functions similarly to the food menu, except it does not have a filtering option.

- Select a beverage from the menu.
- Make the necessary selections from **Options**.
- If desired, make the optional **Addons** selections.
- If desired, add a message to the **Special Requests** via keyboard.
- Select the "Add to Order" button to add item to your order.

### Order Page

The **Order** page has 2 tabs: **Current Order** and **Order History**

- **Current Order** consists of items the user has selected from the **Food** and **Drink** menus, but have not been sent to the kitchen to be prepared.
- **Order History** consists of items that the user have sent to the kitchen to be prepared and served.

Both **Current Order** and **Order History** will display the food and beverage prices - the total under **Current Order** only tallies the prices of items that the user intends to order, while the total under **Order History** is the running total of the user's bill.

If there are one or more items added to the user's order, they can review their choices under the **Current Order** tab and either:

- Remove it from their order (by selecting the red circle with an "x")
- Select "Send to Kitchen" to confirm their order and send it to be prepared

Once "Send to Kitchen" has been selected, the items will show up under the **Order History** tab, which will note that the order is being processed.

The user can quickly reorder an item that they previously ordered during the meal by going to **Order History** > Select the dropdown of an item > Select **Reorder**. The item will be added to the **Current Order** tab for review.

Once the user is finished their meal and ready for the bill, they can go to **Order History** and select **Request Bill**. This signifies the end of the user's dining experience.

### Help Page

The **Help** page has 3 dropdown menus:

- **Getting Started**, which is a walkthrough of the 4 buttons and their functions.
- The **FAQ**, which contains frequently asked questions that may clarify and confusions the user may have
- **Contact Server**, which is a way for the user to type in a message via keyboard to send to their server. If no message is added, the user may simply select **Request Server** in order to ask for a server's presence at their table.
