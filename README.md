# GrayScalingApp

Gray scaling of icons in WPF app

-------------------------

Using **FormatConvertedBitmap** approach is quite efficient. See the image demo bellow.
I use icon 16x16 pixels wide enlarged in WPF to 120 x 120 pixels size:
Or original 16 x 16 pixels look.

When enlarged to 120 x 120 pixles I can see this more preciselly:
The first Tab shows how the original image is gray scaled with opacity lost because FormatConvertedBitmap doesn't preserve the alpha channel when converting to PixelFormats.Gray8.
The second tab uses FormatConvertedBitmap but uses the original Coloured image as an opacity mask for the grayscale version of icon

120 x 120 pixels:

![explorer_ab0BVA8gCp](https://github.com/user-attachments/assets/e003d0c0-160f-4772-b001-947dae559188)

16 x 16 pixles original icon:

![explorer_ZOEwHCCctz](https://github.com/user-attachments/assets/68c3063f-61fd-4df5-9dfd-dd71629f9bdf)

I think it si doable utilizing **FormatConvertedBitmap** class approach
