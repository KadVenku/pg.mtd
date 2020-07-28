# pg.mtd

> ⚠️ **WARNING**: In an attempt to solidify and unite all Alamo-Engine related tools/libraries made by the Empire at War community, development has been moved to the consolidated [AlamoEngine-Tools/PetroglyphTools](https://github.com/AlamoEngine-Tools/PetroglyphTools) repository.

Implements the Petroglyph v1.0 mtd file type in `C#`.

Special thanks to [@MikeLankamp](https://github.com/MikeLankamp) for decoding the files and hosting them on [Petrolution](https://modtools.petrolution.net/docs/MtdFileFormat).

Mega-Texture Directories (extension: `.MTD`) in Petroglyph's games are used to store a list of `<image name, image info>` pairs, essentially a directory of images. The image info is a set of (X,Y) coordinates and Width x Height. This information describes a rectangle in another image file, where this image is located.

By this method, many small images can be packed into one large image (the Mega-Texture) and located again through the accompanying directory. Doing this saves overhead creating every small file.

## Specification

Each Mega-Texture Directory begins with a header, followed by the image index table.

### Header

| Offset | Name | Type | Description |
|:------:|:----:|:----:|:------------|
| `+0000h` | count | `uint32` | Number of records in the Images Index Table |

### Image Index Table Record

| Offset | Name | Type | Description |
|:------:|:----:|:----:|:------------|
| `+0000h` | name | `64 bytes` | ASCII name of the image, zero-padded (append) if less than 64 bytes long. |
| `+0004h` | xPosition | `uint32` | X position in the Mega-Texture of the image, in pixels. |
| `+0004h` | yPosition | `uint32` | Y position in the Mega-Texture of the image, in pixels. |
| `+0004h` | width | `uint32` | Width of the image, in pixels. |
| `+0004h` | height | `uint32` | Height of the image, in pixels. |
| `+0004h` | alpha | `uint8` | 1 if this image uses the Alpha Channel |

## Border Extension
The following information is critical if you plan on creating MTD files!

Because the Mega-Texture is created and used a texture on 3D primitives (although screen-align), round-off sampling errors can still occur, potentially showing a single line of pixels from another image to either side of the image.
To prevent this, all images have their border extended by one pixel when they are packed in the Mega-Texture. However, the Image Index indicates the original area. This means that when packing additional images into a Mega-Texture, the 1-pixel area around existing images should be treated as reserved and filled with the border for new images.
