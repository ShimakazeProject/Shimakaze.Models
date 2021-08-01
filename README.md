# `Shimakaze.Models`

This Repo is file models about **CNC Files**

This repo includes the following

- [`Shimakaze.Models`](#shimakazemodels)
  - [`Shimakaze.Models.Csf`](#shimakazemodelscsf)
  - [`Shimakaze.Models.Ini`](#shimakazemodelsini)

|| Build Status |
|:-:|:-:|
`Shimakaze.Models.Csf`|[![Build and Test Shimakaze.Models.Csf](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Csf.yml/badge.svg)](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Csf.yml)
`Shimakaze.Models.Ini`|[![Build and Test Shimakaze.Models.Ini](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Ini.yml/badge.svg)](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Ini.yml)

## `Shimakaze.Models.Csf`

A simple of C&C CSF File Model.  
About Read and Write you need to see [`Shimakaze.Tools`](//github.com/ShimakazeProject/Shimakaze.Tools)

## `Shimakaze.Models.Ini`

A simple of C&C `Ini` File Model.

This lib can help you to easily to edit `Ini` File.

Sample:
- Read and Write File
    - Synchronization Code:
        ```cs
        // using
        using Shimakaze.Models.Ini;
        using Shimakaze.Models.Ini.Serialization;

        // Deserialize
        TextReader tr;

        IniDocument Ini = IniSerializer.Deserialize(tr);

        // Serialize
        IniDocument Ini;
        TextWriter tw;

        IniSerializer.Serialize(Ini, tw);
        ```
    - Asynchronization Code:
        ```cs
        // using
        using Shimakaze.Models.Ini;
        using Shimakaze.Models.Ini.Serialization;

        // Deserialize
        TextReader tr;

        IniDocument Ini = await IniSerializer.DeserializeAsync(tr);

        // Serialize
        IniDocument Ini;
        TextWriter tw;

        await IniSerializer.SerializeAsync(Ini, tw);
        ```


- Edit `IniDocument` Object
    - Read Data
        ```cs
        IniDocument ini;

        dynamic dini = ini;

        // Get Section

        // You can get Section by Indexer.
        IniSection section = ini["Section"];
        // You can also get Section by dynamic Token.
        dynamic dsection = dini.Section; // The type is IniSection

        // Get Value

        // You can direct get value from IniDocument by Indexer. (Recommend)
        IniValue value = ini["Section", "Key"];
        // You can get value from IniSection by Indexer.
        IniValue value2 = ini["Section"]["Key"];
        IniValue value3 = section["Key"];

        // You can also get Section by dynamic Token.
        dynamic value4 = dini.Section.Key; // The type is IniValue
        dynamic value5 = dsection.Key; // The type is IniValue

        // the IniValue type can explicit convert to basic types.
        // Warn: we Not Support character type.
        // but you can explicit convert to short integer or other integer types.
        string str = (string)value;
        int i = (int)value;
        bool flag = (bool)value;
        double num = (double)value;
        ```
    - Write Data
        ```cs
        IniDocument ini = new();
        // Warn: You can Not used dynamic Token to write data!

        // You can direct set value from IniDocument by Indexer. (Recommend)
        ini["Section", "Key"] = 1;


        // Warn: You can NOT create unnamed section.
        // Warn: You can Not create Section from Indexer IniDocument[string sectionName] .
        // You can create IniSection by IniDocument.Add(string) method.
        IniSection section1 = ini.Add("Section1");

        // You can also create IniSection by Constructor
        IniSection section2 = new("Section2");
        ini.Add(section2);

        // the IniValue type can implicit convert from basic types.
        IniValue value1 = "From String";
        IniValue value2 = 0.5;
        IniValue value3 = false;
        IniValue value3 = 123;
        IniValue value3 = 321L;
        ```







