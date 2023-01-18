
![example 1.0](https://ric0x101010.github.io/xivmicroparser/img/example_1.0.png)

# xivmicropaser Dalamud
XIV Micro Parser Plugin for Dalamud.
There is also an alternative version as ACT Overlay: https://github.com/ric0x101010/xivmicroparser 

It serves as a simplified presentation of the most important information about the fight.
Broken down to:
- The actual Fight Time.
- The Time to Kill (TTK). **Is calculated on the basis of the current rDPS and can be different, but is only intended as a guideline.** 
- Kill Time (KT), calculated on Time in Fight and Time to Kill
- Progress Bar
- The group DPS.

### Test Feature
- Checkbox for 50% TTK, this is there to get the time to kill for the 50% limit in fights like P8S P1. The percentage is also calculated with half of the HP so that 0% is displayed at 50% HP.

### Quick setup
- Use /xlplugins to open the plugin menu
- Click the Settings button at the bottom and go to the Experimental tab
- Add https://raw.githubusercontent.com/ric0x101010/xivmicroparserdalamud/master/repo.json to the Custom Plugin Repositories list and click the '+' button
- Click Save and Close
- xivmicropaser Dalamud should appear in the available plugins list.

