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
    byte[] fileData = serializer.Serialize(fileData);
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