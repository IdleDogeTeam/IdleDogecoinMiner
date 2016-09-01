#! /bin/sh

project="IdleDogeMiner"



echo "Attempting to build $project for Windows"

/Applications/Unity/Unity.app/Contents/MacOS/Unity \

  -batchmode \

  -nographics \

  -silent-crashes \


  -projectPath $(pwd) \

  -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \

  -quit


echo 'done'