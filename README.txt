Settings project RANDOM

To add a flexible adjustment in the App.config or Web.config:
  
  <configuration>
  
    <configSections>
      <section name="generateSettings" type="RANDOM.GenerateSettings, RANDOM, Version=1.0.0.0, Culture=neutral" />
    </configSections>

    <generateSettings>
      <registerCode codeLength="15" symbols="0123456789"/>
      <password length="10" symbols="abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-"/>
    </generateSettings>

    </configuration>



  Default settings:
    * registerCode -> codeLength: 10, symbols: abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-
    * password -> length: 10, symbols: abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-