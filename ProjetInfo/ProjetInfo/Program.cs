using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjetInfo
{
	class MainClass
	{
		static void Main(string[] args)
		{
			
			Console.ForegroundColor = ConsoleColor.Cyan;
			Centrer("BIENVENUE SUR UN TRAITEMENT D'IMAGE ");
			Centrer("by Henri de Montalembert\n");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Quelle est l'image que vous voulez modifier : ");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Vous avez le choix entre les images suivantes :\n");
			Console.ResetColor();
			string[] Tab = { "-Lac en montagne ", "-Une photo de Paris ", "-Une image d'une maison créé sur c# en faisant un assemblage de forme géométrique (Innovation)" };

			int Ligne = 0;
			Select(Tab, Ligne);



			ConsoleKeyInfo C = Console.ReadKey();

			while (C.Key != ConsoleKey.Enter)
			{
				if (C.Key == ConsoleKey.DownArrow) Ligne++;
				if (C.Key == ConsoleKey.UpArrow) Ligne--;
				if (Ligne == -1) Ligne = 0;
				if (Ligne == Tab.Length) Ligne = Tab.Length - 1; Console.Clear();

				Console.ForegroundColor = ConsoleColor.Cyan;
				Centrer("BIENVENUE SUR UN TRAITEMENT D'IMAGE ");
				Centrer("by Henri de Montalembert\n");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Quelle est l'image que vous voulez modifier : ");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Vous avez le choix entre les images suivantes :\n");
				Console.ResetColor();
				Select(Tab, Ligne);
				C = Console.ReadKey();

			}
			if (Ligne == 0)
			{
				byte[] TabImage = File.ReadAllBytes("lac_en_montagne.bmp");
				MyImage MonImage = new MyImage(TabImage);
				Affichage(MonImage, TabImage);
		    }
			if (Ligne == 1)
			{
				byte[] TabImage = File.ReadAllBytes("Paris.bmp");
				MyImage MonImage = new MyImage(TabImage);
				Affichage(MonImage, TabImage);
			}
			if (Ligne == 2)
			{
				byte[] TabImage = File.ReadAllBytes("ImageInnov2.bmp");
				MyImage MonImage = new MyImage(TabImage);
				Affichage(MonImage, TabImage);
			}

			Console.ForegroundColor = ConsoleColor.Cyan;

			Console.WriteLine("\nAllez voir dans le dossier debug vos/votre image(s) modifée(s)");
           

			Console.ReadKey();
		}
		static void Affichage(MyImage MonImage, byte[] TabImage)
		{
			string B = "oui";
			while (B == "oui")
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nQue voulez vous faire :\n");
				Console.ResetColor();
				//string C = "oui";
				string[] Tab = {"-Afficher les informations sur l'image", "-Une rotation sur l'image (90,180 ou 270°)" , "-Modifier l'image en nuance de gris " , "-Modifier l'image en noir et blanc" ,
				 "-Modifier l'image en négatif","-Créer une image avec l'initiale de Henri", "-Créer une image avec une forme géométrique " , "-Matrice de convolution : flou" ,
				  "-Matrice de convolution : Détection de contour",   "-Matrice de convolution : Netteté ",  "-Créer une image qui affiche mon innovation "};
				int Ligne = 0;

				Select(Tab, Ligne);

				ConsoleKeyInfo C = Console.ReadKey();

				while (C.Key != ConsoleKey.Enter)
				{
					if (C.Key == ConsoleKey.DownArrow) Ligne++;
					if (C.Key == ConsoleKey.UpArrow) Ligne--;
					if (Ligne == -1) Ligne = 0;
					if (Ligne == Tab.Length) Ligne = Tab.Length - 1; 
					Console.ForegroundColor = ConsoleColor.Green; Console.Clear();
					Console.WriteLine("\nQue voulez vous faire :\n");
					Console.ResetColor();
					Select(Tab, Ligne);
					C = Console.ReadKey();

				}

				switch (Ligne)
				{
					case 0:
						Console.Clear();
						MonImage.ToString();
						break;
					case 1:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\nUne rotation de : "); Console.ResetColor();
						string[] Tab3 = { "-90°", "-180°", "-270°" };
						int Ligne3 = 0;
						Select(Tab3, Ligne3);
						C = Console.ReadKey();
						while (C.Key != ConsoleKey.Enter)
						{
							if (C.Key == ConsoleKey.DownArrow) Ligne3++;
							if (C.Key == ConsoleKey.UpArrow) Ligne3--;
							if (Ligne3 == -1) Ligne3 = 0;
							if (Ligne3 == Tab3.Length) Ligne3 = Tab3.Length - 1; Console.Clear();
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("\nUne rotation de : "); Console.ResetColor();
							Select(Tab3, Ligne3);
							C = Console.ReadKey();

						}


						if (Ligne3 == 0) Rotation90(MonImage);

						if (Ligne3 == 1) Rotation180(MonImage);

						if (Ligne3 == 2) Rotation270(MonImage);
						break;
					case 2:
						
						NuanceDeGris(MonImage, "nuanceDeGris");
						break;
					case 3:
						NoirEtBlanc(MonImage, "NoirEtBlanc");
						break;
					case 4:
						Negatif(MonImage);


						break;
					case 5:
						InitialePrenom(MonImage);

						break;
					case 6:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\nQuelle forme? "); Console.ResetColor();

						string[] Tab4 = { "-Héxagone", "-Losange", "-Rond" };
						int Ligne4 = 0;
						Select(Tab4, Ligne4);
						C = Console.ReadKey();
						while (C.Key != ConsoleKey.Enter)
						{
							if (C.Key == ConsoleKey.DownArrow) Ligne4++;
							if (C.Key == ConsoleKey.UpArrow) Ligne4--;
							if (Ligne4 == -1) Ligne4 = 0;
							if (Ligne4 == Tab4.Length) Ligne4 = Tab4.Length - 1; Console.Clear();
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("\nQuelle forme? "); Console.ResetColor();
							Select(Tab4, Ligne4);
							C = Console.ReadKey();

						}

						if (Ligne4 == 0) Hexagone(MonImage);
						if (Ligne4 == 1) Losange(MonImage);
						if (Ligne4 == 2) Rond(MonImage);
						break;
					case 7:

						MatriceDeConvolution(MonImage, Flou(), 25, "Flou");

						break;
					case 8:
						MatriceDeConvolution(MonImage, DetectionDesBords(), 1, "DetectionDesBords");
						break;
					case 9:
						MatriceDeConvolution(MonImage, Netteté(), 1, "Netteté");
						break;
					case 10:
						Innovation();
						break;



				}

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Voullez vous faire autre chose? (oui ou non) :"); Console.ResetColor();
				string[] Tab2 = { "-oui", "-non" };
				int Ligne2 = 0;
				Select(Tab2, Ligne2);
				C = Console.ReadKey();
				while (C.Key != ConsoleKey.Enter)
				{
					if (C.Key == ConsoleKey.DownArrow) Ligne2++;
					if (C.Key == ConsoleKey.UpArrow) Ligne2--;
					if (Ligne2 == -1) Ligne2 = 0;
					if (Ligne2 == Tab2.Length) Ligne2 = Tab2.Length - 1; Console.Clear();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Voullez vous faire autre chose? (oui ou non) :"); Console.ResetColor();
					Select(Tab2, Ligne2);
					C = Console.ReadKey();

				}
				if (Ligne2 == 0) B = "oui";
				if (Ligne2 == 1) B = "non";

			}

		}

		#region Méthodes
		static void Select(string[] Tab, int Ligne)
		{

			for (int i = 0; i < Tab.Length; i++)
			{
				if (i == Ligne)
				{
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					Console.WriteLine(Tab[i]); Console.ResetColor();
				}
				else Console.WriteLine(Tab[i]);

			}
		}


		static int[,] Netteté()
		{
			int[,] Mat = { { 0, 0, 0, 0, 0 }, { 0, -1, -1, -1, 0 }, { 0, -1, 9, -1, 0 }, { 0, -1, -1, -1, 0 }, { 0, 0, 0, 0, 0 } };
			return Mat;
		}
		static int[,] DetectionDesBords()
		{
			int[,] Mat = { { 0, 0, 0, 0, 0 }, { 0, -1, -1, -1, 0 }, { 0, -1, 8, -1, 0 }, { 0, -1, -1, -1, 0 }, { 0, 0, 0, 0, 0 } };
			return Mat;
		}
		static int[,] Flou()
		{

			int[,] Mat = { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };
			return Mat;
		}

		static void MatriceDeConvolution(MyImage Image, int[,] Mat, int b , string Nom)
		{
			Pixel[,] MatNew = new Pixel[Image.Hauteur, Image.Largeur];

			for (int a = 0; a < Image.Hauteur; a++)
				for (int c = 0; c < Image.Largeur; c++)
					MatNew[a, c] = Image.Mat1[a, c];

			for (int i = 2; i < Image.Hauteur - 2; i++) 
			{
				for (int j = 2; j < Image.Largeur - 2; j++)
				{
					Pixel[,] Mat3 = new Pixel[5, 5];

					for (int c = 0; c <  5; c++)
						for (int d = 0; d <  5; d++)
						{
						Mat3[c, d] = Image.Mat1[i - 2 + c, j - 2+d];
						}

					int B = 0, C = 0, D = 0;

					for (int I = 0; I < 5; I++)
					{
						for (int J = 0; J < 5; J++)
						{
							B += Mat[I, J] * Mat3[I, J].R1;
							C += Mat[I, J] * Mat3[I, J].G1;
							D += Mat[I, J] * Mat3[I, J].B1;
						}
					}
					B = B / b;
					C = C / b;
					D = D / b;
					if (B < 0) B = 0;
					if (C < 0) C = 0;
					if (D < 0) D = 0;
					if (B > 255) B = 255;
					if (C > 255) C = 255;
					if (D > 255) D = 255;

					byte B1 = Convert.ToByte(B);
					byte C1 = Convert.ToByte(C);
					byte D1 = Convert.ToByte(D);



					MatNew[i, j] = new Pixel(B1, C1, D1);


				}

			}
			Image.From_Image_ToFile(MatNew, Nom);
		}

		static void Centrer(string text)
		{
			int Nb = (Console.WindowWidth - text.Length) / 2;
			Console.SetCursorPosition(Nb, Console.CursorTop);
			Console.WriteLine(text);
		}
		static void Negatif(MyImage Image)
		{
			Pixel[,] Mat = new Pixel[Image.Hauteur, Image.Largeur];

			for (int i = 0; i < Image.Hauteur; i++)
			{
				for (int j = 0; j < Image.Largeur; j++)
				{
					byte R = Convert.ToByte(255 - Image.Mat1[i, j].R1);
					byte G = Convert.ToByte(255 - Image.Mat1[i, j].G1);
					byte B = Convert.ToByte(255 - Image.Mat1[i, j].B1);


					Mat[i, j] = new Pixel(R, G, B);
				}
			}
			Image.From_Image_ToFile(Mat,"Negatif");
		}

		static void NoirEtBlanc(MyImage Image, string Nom)
		{
			Pixel[,] Mat = new Pixel[Image.Hauteur, Image.Largeur];

			for (int i = 0; i < Image.Hauteur; i++)
			{
				for (int j = 0; j < Image.Largeur; j++)
				{
					int M = (Image.Mat1[i, j].R1 + Image.Mat1[i, j].G1 + Image.Mat1[i, j].B1) / 3;
					byte M1 = Convert.ToByte(M);
					if (M1 < 128)
					{
						Mat[i, j] = new Pixel(0, 0, 0);

					}
					else
					{
						Mat[i, j] = new Pixel(255, 255, 255);
					}
				}
			}
            Image.From_Image_ToFile(Mat, Nom);
		}

		static void NuanceDeGris(MyImage Image , string Nom)
		{
			Pixel[,] Mat = new Pixel[Image.Hauteur, Image.Largeur];
			for (int i = 0; i < Image.Hauteur; i++)
			{
				for (int j = 0; j < Image.Largeur; j++)
				{
					int M = (Image.Mat1[i, j].R1 + Image.Mat1[i, j].G1 + Image.Mat1[i, j].B1) / 3;
					byte M1 = Convert.ToByte(M);

					Mat[i, j] = new Pixel(M1, M1, M1);
				}
			}
			Image.From_Image_ToFile(Mat,Nom);
		}
		static void InitialePrenom(MyImage Image)
		{
			int i;
			int j;
			int x = Image.Hauteur;
			int y = Image.Largeur;

			Pixel[,] Mat3 = new Pixel[Image.Hauteur, Image.Largeur];

			for (int a = 0; a < x; a++)
			{
				for (int b = 0; b < y; b++)
				{
					Mat3[a, b] = Image.Mat1[a, b];
				}
			}
			for (i = x / 6; i < x / 1.9; i++)
			{
				for (j = y / 4; j < y / 3; j++)
				{

					Mat3[i, j] = new Pixel(255, 255, 255);

				}
			}
			for (i = x / 6; i < x / 1.9; i++)
			{
				for (j = y / 2; j > y / 2.4; j--)
				{

					Mat3[i, j] = new Pixel(255, 255, 255);
				}
			}
			for (i = x / 3; i < x / 2.5; i++)
			{
				for (j = y / 3; j < y / 2.4; j++)
				{
					Mat3[i, j] = new Pixel(255, 255, 255);
				}
			}


			Image.From_Image_ToFile(Mat3,"Initiale");
		}
		static void Hexagone(MyImage Image)
		{
			int x = Image.Hauteur;
			int y = Image.Largeur;
			Pixel[,] NewMat = new Pixel[x, y];

			for (int a = 0; a < x; a++)
				for (int b = 0; b < y; b++)
					NewMat[a, b] = new Pixel(0, 0, 0);

			for (double i = x / 2.9; i < x / 1.98; i++)
			{
				for (double j = y / 3; j < y / 1.6; j++)
				{
					int I = Convert.ToInt32(i);
					int J = Convert.ToInt32(j);
					NewMat[I, J].R1 = 255;
					NewMat[I, J].G1 = 255;
					NewMat[I, J].B1 = 255;
				}
			}
			int compt = 0;
			for (double i = x / 1.98; i < x / 1.6; i++)
			{
				for (int j = y / 3 + compt; j < y / 1.6 - compt; j++)
				{
					int I = Convert.ToInt32(i);
					NewMat[I, j].R1 = 255;
					NewMat[I, j].G1 = 255;
					NewMat[I, j].B1 = 255;
				}
				compt++;
			}
			compt = 0;
			for (double i = x / 2.9; i > x / 4.3; i--)
			{
				for (int j = y / 3 + compt; j < y / 1.6 - compt; j++)
				{
					int I = Convert.ToInt32(i);
					NewMat[I, j].R1 = 255;
					NewMat[I, j].G1 = 255;
					NewMat[I, j].B1 = 255;
				}
				compt++;
			}
			Image.From_Image_ToFile(NewMat,"FormeGeo");
		}
		static Pixel[,] Triangle(MyImage Image)
		{
			int x = Image.Hauteur;
			int y = Image.Largeur;
			int compt = 0;
			for (int i = x / 6; i < x / 1.9; i++)
			{
				for (int j = y / 4 + compt; j < y / 1.2 - compt; j++)
				{
					Image.Mat1[i, j].R1 = 255;
					Image.Mat1[i, j].G1 = 255;
					Image.Mat1[i, j].B1 = 255;
				}
				compt++;
			}
			return Image.Mat1;
		}
		static void Rond(MyImage Image)
		{
			int x = Image.Hauteur;
			int y = Image.Largeur;
			Pixel[,] NewMat = new Pixel[x, y];
			Random R = new Random();
			for (int a = 0; a < x; a++)
				for (int b = 0; b < y; b++)
					NewMat[a, b] = new Pixel(0,0,0);
			for (int a = 0; a < x; a++)
			{
				for (int b = 0; b < y; b++)
				{ 
					NewMat[a, b].R1 = Convert.ToByte(R.Next(1, 255));
					NewMat[a, b].G1 = Convert.ToByte(R.Next(1, 255));
					NewMat[a, b].B1 = Convert.ToByte(R.Next(1, 255));
				}
			}
			double j = 0;
			double i = 0;
			int J;
			int I;
			for (i = 0; i < x; i++)
			{
				for (j = 0; j < y; j++)
				{
					int Centre1 = x / 2;
					int Centre2 = y / 2;
					double D = Math.Sqrt((i - Centre1) * (i - Centre1) + (j - Centre2) * (j - Centre2));
					J = Convert.ToInt32(j);
					I = Convert.ToInt32(i);
					if (D < y / 4)
					{
						NewMat[I, J].R1 = 255;
						NewMat[I, J].G1 = 255;
						NewMat[I, J].B1 = 255;
					}

				}

			}
			Image.From_Image_ToFile(NewMat,"FormeGeo");
		}
		static void Losange(MyImage Image)
		{
			
			int x = Image.Hauteur;
			int y = Image.Largeur;

			Pixel[,] NewMat = new Pixel[x, y];

			for (int a = 0; a < x; a++)
				for (int b = 0; b < y; b++)
					NewMat[a, b] = new Pixel(0, 0, 0);
			int compt = 0;
			for (int i = x / 2; i < x / 1.05; i++)
			{
				for (int j = y / 4 + compt; j < y / 1.4 - compt; j++)
				{
					NewMat[i, j] = new Pixel(255, 255, 255);
				}
				compt++;
			}
			compt = 0;
			for (int i = x / 2; i > x / 12; i--)
			{
				for (int j = y / 4 + compt; j < y / 1.4 - compt; j++)
				{
					NewMat[i, j] = new Pixel(255, 255, 255);

				}
				compt++;
			}
			Image.From_Image_ToFile(NewMat, "FormeGeo");

		}
		static void Innovation()
		{
			byte[] TabImage = File.ReadAllBytes("lena.bmp");
			MyImage MonImage = new MyImage(TabImage);

			for (int i = 0; i < MonImage.Hauteur; i++)
			{
				for (int j = 0; j < MonImage.Largeur; j++)
				{

					MonImage.Mat1[i, j].R1 = 144;
					MonImage.Mat1[i, j].G1 = 233;
					MonImage.Mat1[i, j].B1 = 135;



				}
			}

			for (double i = MonImage.Hauteur / 1.6; i < MonImage.Hauteur; i++)
			{
				for (int j = 0; j < MonImage.Largeur; j++)
				{
					int I = Convert.ToInt32(i);
					MonImage.Mat1[I, j].R1 = 236;
					MonImage.Mat1[I, j].G1 = 196;
					MonImage.Mat1[I, j].B1 = 38;
				}
			}

			int x = MonImage.Hauteur;
			int y = MonImage.Largeur;
			int compt = 0;

			for (int i = x / 2; i < x / 1.1; i++)
			{
				for (int j = y / 4 + compt; j < y / 1.2 - compt; j++)
				{
					
					MonImage.Mat1[i, j].R1 = 38;
					MonImage.Mat1[i, j].G1 = 103;
					MonImage.Mat1[i, j].B1 = 167;

				}
				compt++;
				//compt2++;
			}
			for (int i = x / 2; i > x / 20; i--) // gros carré
			{
				for (int j = y / 4; j < y / 1.2; j++)
				{
					MonImage.Mat1[i, j].R1 = 220;
					MonImage.Mat1[i, j].G1 = 245;
					MonImage.Mat1[i, j].B1 = 245;
				}
			}
			for (int i = x / 20; i < x / 3.6; i++) // porte 
			{
				for (int j = y / 2; j < y / 1.5; j++)
				{
					MonImage.Mat1[i, j].R1 = 38;
					MonImage.Mat1[i, j].G1 = 103;
					MonImage.Mat1[i, j].B1 = 167;
				}
			}
			for (double i = (x / 20 + x / 3.6) / 2; i < (x / 20 + x / 3.6) / 1.8; i++)
			{
				for (double j = y / 1.6; j < y / 1.55; j++)
				{
					int J = Convert.ToInt32(j);
					int I = Convert.ToInt32(i);
					MonImage.Mat1[I, J].R1 = 0;
					MonImage.Mat1[I, J].G1 = 0;
					MonImage.Mat1[I, J].B1 = 0;
				}
			}

			for (int i = x / 3; i < x / 2.1; i++) // fenetre 
			{
				for (int j = x / 3; j < x / 2.1; j++)
				{
					MonImage.Mat1[i, j].R1 = 208;
					MonImage.Mat1[i, j].G1 = 208;
					MonImage.Mat1[i, j].B1 = 128;
				}
			}
			for (int i = x / 3; i < x / 2.1; i++) // 2eme fenetre
			{
				for (double j = x / 1.6; j < x / 1.3; j++)
				{
					int J = Convert.ToInt32(j);
					MonImage.Mat1[i, J].R1 = 208;
					MonImage.Mat1[i, J].G1 = 208;
					MonImage.Mat1[i, J].B1 = 128;
				}
			}

			for (int i = x / 3; i > x / 20; i--) // tronc du sapin 
			{
				for (int j = y / 10; j < y / 7; j++)
				{
					MonImage.Mat1[i, j].R1 = 27;
					MonImage.Mat1[i, j].G1 = 86;
					MonImage.Mat1[i, j].B1 = 0;
				}
			}
			int C = 0;
			for (int i = x / 10; i < x / 2; i++)                       // Triangle sapin
			{
				for (int j = 0 + C; j < y / 4.2 - C; j++)
				{
					MonImage.Mat1[i, j].R1 = 27;
					MonImage.Mat1[i, j].G1 = 86;
					MonImage.Mat1[i, j].B1 = 0;
				}
				C++;
			}
			C = 0;
			for (int i = x / 6; i < x / 2; i++)
			{
				for (int j = 0 + C; j < y / 4.2 - C; j++)
				{
					MonImage.Mat1[i, j].R1 = 27;
					MonImage.Mat1[i, j].G1 = 86;
					MonImage.Mat1[i, j].B1 = 0;
				}
				C++;
			}
			C = 0;
			for (double i = x / 4.25; i < x / 2; i++)
			{
				for (int j = 0 + C; j < y / 4.2 - C; j++)
				{
					int I = Convert.ToInt32(i);
					MonImage.Mat1[I, j].R1 = 27;
					MonImage.Mat1[I, j].G1 = 86;
					MonImage.Mat1[I, j].B1 = 0;
				}
				C++;
			}
			C = 0;
			for (double i = x / 3.4; i < x / 2; i++)
			{
				for (int j = 0 + C; j < y / 4.2 - C; j++)
				{
					int I = Convert.ToInt32(i);
					MonImage.Mat1[I, j].R1 = 27;
					MonImage.Mat1[I, j].G1 = 86;
					MonImage.Mat1[I, j].B1 = 0;
				}
				C++;
			}
			for (double i = x / 1.25; i < x / 1.17; i++)   // soleil 
			{
				for (double j = y / 10; j < y / 4; j++)
				{
					int I = Convert.ToInt32(i);
					int J = Convert.ToInt32(j);
					MonImage.Mat1[I, J].R1 = 0;
					MonImage.Mat1[I, J].G1 = 255;
					MonImage.Mat1[I, J].B1 = 255;
				}
			}

			int C2 = 0;
			for (double i = x / 1.17; i < x / 1.11; i++)
			{
				for (int j = y / 10 + C2; j < y / 4 - C2; j++)
				{
					int I = Convert.ToInt32(i);
					MonImage.Mat1[I, j].R1 = 0;
					MonImage.Mat1[I, j].G1 = 255;
					MonImage.Mat1[I, j].B1 = 255;
				}
				C2++;
			}
			C2 = 0;
			for (double i = x / 1.25; i > x / 1.32; i--)
			{
				for (int j = y / 10 + C2; j < y / 4 - C2; j++)
				{
					int I = Convert.ToInt32(i);
					MonImage.Mat1[I, j].R1 = 0;
					MonImage.Mat1[I, j].G1 = 255;
					MonImage.Mat1[I, j].B1 = 255;
				}
				C2++;
			}

			MonImage.From_Image_ToFile(MonImage.MAT1,"Innovation");
		}
		static void Rotation90(MyImage MonImage)
		{
			Pixel[,] Mat3 = new Pixel[MonImage.Largeur, MonImage.Hauteur];

			for (int i = 0; i < MonImage.Largeur; i++)
			{
				for (int j = 0; j < MonImage.Hauteur; j++)
				{
					Mat3[i, j] = MonImage.Mat1[MonImage.Hauteur - j - 1, i];

				}
			}


			MonImage.From_Image_ToFile(Mat3,"Rotation");
		}

		static void Rotation180(MyImage Image)
		{


			Pixel[,] Mat3 = new Pixel[Image.Largeur, Image.Hauteur];

			for (int i = 0; i < Image.Largeur; i++)
			{
				for (int j = 0; j < Image.Hauteur; j++)
				{
					Mat3[i, j] = Image.Mat1[Image.Hauteur - j - 1, i];

				}
			}
			Pixel[,] Mat4 = new Pixel[Image.Hauteur, Image.Largeur];

			for (int i = 0; i < Image.Hauteur; i++)
			{
				for (int j = 0; j < Image.Largeur; j++)
				{
					Mat4[i, j] = Mat3[Image.Largeur - j - 1, i];

				}
			}


			Image.From_Image_ToFile(Mat4,"Rotation");
		}


		static void Rotation270(MyImage Image)
		{

			Pixel[,] Mat3 = new Pixel[Image.Largeur, Image.Hauteur];

			for (int i = 0; i < Image.Largeur; i++)
			{
				for (int j = 0; j < Image.Hauteur; j++)
				{
					Mat3[i, j] = Image.Mat1[Image.Hauteur - j - 1, i];

				}
			}
			Pixel[,] Mat4 = new Pixel[Image.Hauteur, Image.Largeur];

			for (int i = 0; i < Image.Hauteur; i++)
			{
				for (int j = 0; j < Image.Largeur; j++)
				{
					Mat4[i, j] = Mat3[Image.Largeur - j - 1, i];

				}
			}
			Pixel[,] Mat5 = new Pixel[Image.Largeur, Image.Hauteur];

			for (int i = 0; i < Image.Largeur; i++)
			{
				for (int j = 0; j < Image.Hauteur; j++)
				{
					Mat5[i, j] = Mat4[Image.Hauteur - j - 1, i];

				}
			}


			Image.From_Image_ToFile(Mat4, "Rotation");

		}

			
		#endregion


	}

}

