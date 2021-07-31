# Shimakaze.Models

This Repo is file models about CNC Files

## Shimakaze.Models.Csf [![Build and Test Shimakaze.Models.Csf](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Csf.yml/badge.svg)](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Csf.yml)

A simple of C&C CSF File Model.

You can be easy to use this to Serialize/Deserialize CSF file.

Sample:

- Synchronization Code:
    ```cs
    // using
    using Shimakaze.Models.Csf;
    using Shimakaze.Models.Csf.Serialization;

    // Deserialize
    byte[] fileData;

    CsfStructSerializer serializer = new();
    CsfStruct csf = serializer.Deserialize(fileData);

    // Serialize
    CsfStruct csf;

    CsfStructSerializer serializer = new();
    byte[] fileData = serializer.Serialize(csf);
    ```
- Asynchronization Code:
    ```cs
    // using
    using Shimakaze.Models.Csf;
    using Shimakaze.Models.Csf.Serialization;

    // Deserialize
    Stream fileStream;
    byte[] buffer;

    CsfStructSerializer serializer = new();
    CsfStruct csf = await serializer.DeserializeAsync(fileStream, buffer);

    // Serialize
    CsfStruct csf;
    Stream fileStream;

    CsfStructSerializer serializer = new();
    await serializer.SerializeAsync(csf, fileStream);
    ```

## Shimakaze.Models.Ini [![Build and Test Shimakaze.Models.Ini](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Ini.yml/badge.svg)](https://github.com/ShimakazeProject/Shimakaze.Models/actions/workflows/Shimakaze.Models.Ini.yml)

A simple of C&C Ini File Model.

You can be easy to use this to Serialize/Deserialize Ini file.

Sample:

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