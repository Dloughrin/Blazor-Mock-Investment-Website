# Blazor Mock Investment Website

This website keeps track of various types of information in SQL databases. This includes usernames and passwords, all investments associated with each 
username, support tickets, and assets for the hypothetical company that the website is for.

## User Data
As briefly mentioned, each user hasa an associated username and password. For the purposes of testing and simplicity, the UI only has you set up effectively
a username to be utilized on the website. There is also a default account called Customer Support Agent that has a tag to mark it able to see and respond to
all support tickets.

Users can add company assets, personal investments and send in support tickets. These will all be visible in the respective tab when they are logged in.

## Assets
Assets values are tracked based on salvage value, years until they are considered "expired," and how long they've been available. There is a graph that will
display both the individual asset's value and the total for all assets.

## Investments
Similar to assets, the value for all investments a user has made can be seen and tracked in the given tab. Customer Support accounts can edit all investments 
regardless of who created them, but otherwise each investment can only be modified by the user that originally created it.

## Support Tickets
Using a basic form layout, anyone can send in a support ticket and give the required information, even those who are not logged in. Support Agents can mark these
as completed or not, but no other users can see these.
