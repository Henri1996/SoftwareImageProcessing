using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace ProjetInfo
{
	public class MyImage
	{
		
		private byte[] TabImage;

		private int tailledufichier;
		private int tailleoffset;
		private int largeur;
		private int hauteur;
		private int NbBitsParCouleur;
		private Pixel[,] Mat;
		private Pixel[,] MAT;
		string TypeDimage1;



		#region Propriété




		public int Tailledufichier
		{
			get
			{
				return tailledufichier;
			}


		}

		public int Tailleoffset
		{
			get
			{
				return tailleoffset;
			}


		}

		public int Largeur
		{
			get
			{
				return largeur;
			}


		}

		public int Hauteur
		{
			get
			{
				return hauteur;
			}


		}

		public int NbBitsParCouleur1
		{
			get
			{
				return NbBitsParCouleur;
			}


		}

		internal Pixel[,] Mat1
		{
			get
			{
				return Mat;
			}


		}

		public byte[] TabImage1
		{
			get
			{
				return TabImage;
			}


		}

		internal Pixel[,] MAT1
		{
			get
			{
				return MAT;
			}

			set
			{
				MAT = value;
			}
		}
		#endregion


		//Constructeur 
		public MyImage(byte[] TabImage)
		{
			this.TabImage = TabImage;
			TypeDimage1 = Type(TabImage[0], TabImage[1]);
			largeur = FaireConversion(18, 22);
			hauteur = FaireConversion(22, 26);
			NbBitsParCouleur = FaireConversion(28, 30);
			tailledufichier = FaireConversion(2, 5);
			tailleoffset = FaireConversion(10, 14);

			if (NbBitsParCouleur != 24)
			{
				Console.WriteLine("Pour traiter l'image, il faut que l'image est 24 bits par couleur ");
			}

			if (TypeDimage1 != "BM")
			{
				Console.WriteLine("Pour traiter l'image, il faut que vous ayez du image du type BM");
				return;
			}

			AffecterMatrice();
			//ToString(); // verification de mes conversions sur les infos de l'image 



		}


		public string Type(int a, int b)
		{
			char[] Alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			char f1 = Alpha[a - 65];
			char f2 = Alpha[b - 65];
			string F = Convert.ToString(f1);
			string F2 = Convert.ToString(f2);
			string FORMAT = F + F2;
			return FORMAT;

		}

		public int FaireConversion(int x, int y)
		{

			int j = 0;

			byte[] Tab = new byte[y - x];
			for (int i = x; i < y; i++)
			{
				Tab[j] = TabImage[i];
				j++;
			}
			return Convertir_Endian_To_Int(Tab);
		}

		public void ToString()
		{
			Console.WriteLine("Header info\n");
			Console.WriteLine("Type d'image : " + TypeDimage1);
			Console.WriteLine("Largeur = " + Largeur);
			Console.WriteLine("Hauteur = " + Hauteur);
			Console.WriteLine("Taille du fichier = " + tailledufichier);
			Console.WriteLine("Nombre d'octet par couleur = " + NbBitsParCouleur);
			Console.WriteLine("Taille offset = " + Tailleoffset);
			Console.WriteLine("\n");
			//Console.WriteLine("Matrice de pixel RGB  : \n");




		}

		public void AffecterMatrice()
		{
			

			int nbz = 0;
			if ((largeur) % 4 == 1)
			{
				nbz = 3;
			}
			if ((largeur) % 4 == 2)
			{
				nbz = 2;


			}
			if ((largeur) % 4 == 3)
			{
				nbz = 1;


			}
			Mat = new Pixel[Hauteur, Largeur];
			MAT = new Pixel[Hauteur, Largeur];


			int x = 54;
			for (int i = 0; i < Hauteur; i++)
			{
				for (int j = 0; j < Largeur; j++)
				{

					 
					Mat[i, j] = new Pixel(TabImage[x], TabImage[x + 1], TabImage[x + 2]);
					x = x + 3;
				}
				i = i + nbz;
			}


		}
		public int Convertir_Endian_To_Int(byte[] TAB) // convertir une sequence d'octet little endian en int
		{
			int Valeur = 0;
			for (int i = 0; i < TAB.Length; i++)
			{
				int Nb = Convert.ToInt32(Math.Pow(256, i)); //Math.Pow(2, 8 * x )
				Valeur = Valeur + TAB[i] * Nb;
			}
			return Valeur;

		}

		public byte[] Convertir_Int_To_Endian(int val)
		{
			return BitConverter.GetBytes(val);

		}

		public void From_Image_ToFile( Pixel[,] Mat5, string Nom)
		{

			byte[] Tab = new byte[TabImage.Length];
			byte[] Tab2 = new byte[TabImage.Length];


			int x = 0;
			for (int i = 0; i < Mat5.GetLength(0); i++)
			{
				for (int j = 0; j < Mat5.GetLength(1); j++)
				{



                    Tab[x] = Mat5[i, j].R1;
					Tab[x + 1] = Mat5[i, j].G1;
					Tab[x + 2] = Mat5[i, j].B1;
					x = x + 3;
				}
			}


			for (int i = 0; i < 54; i++)

			{
				Tab2[i] = TabImage[i];

			}
			if (Mat5.GetLength(0) == Largeur)
			{
				int F = 22;
				for (int i = 18; i < 22; i++)
				{
					Tab2[i] = TabImage[F];
					F++;
				}
				int G = 18;
				for (int i = 22; i < 26; i++)
				{
					Tab2[i] = TabImage[G];
					G++;
				}
			}
			int Compt = 0;

			for (int i = 54; i < Tab.Length; i++)
			{
				Tab2[i] = Tab[Compt];
				Compt++;
			}

			File.WriteAllBytes(Nom + ".png", Tab2);

			ProcessStartInfo Sortir = new ProcessStartInfo(@Nom+".png", "");
			Process.Start(Sortir);
		}
		public void From_Image_ToFile2(Pixel[,] Mat5, string Nom)
		{

			byte[] Tab = new byte[TabImage.Length*2];
			byte[] Tab2 = new byte[54 + (TabImage.Length-54)*2];


			int x = 0;
			for (int i = 0; i < Mat5.GetLength(0); i++)
			{
				for (int j = 0; j < Mat5.GetLength(1); j++)
				{


					Tab[x] = Mat5[i, j].R1;
					Tab[x + 1] = Mat5[i, j].G1;
					Tab[x + 2] = Mat5[i, j].B1;
					x = x + 3;
				}
			}


			for (int i = 0; i < 54; i++)

			{
				Tab2[i] = TabImage[i];

			}
			byte[] Larg = Convertir_Int_To_Endian(Largeur * 2);
			byte[] Haut = Convertir_Int_To_Endian(Hauteur * 2);
			byte[] Tai = Convertir_Int_To_Endian(Largeur * Hauteur * 3);


			int F = 18;
			for (int i = 0; i < Larg.Length; i++)
			{
				Tab2[F] = Larg[i];
				F++;
			}
			int G = 22;
			for (int i = 0; i < Haut.Length; i++)
			{
				Tab2[G] = Haut[i];
				G++;
			}
			int J = 2;
			for (int i = 0; i < Tai.Length; i++)
			{
				Tab2[F] = Tai[i];
				J++;
			}
			int Compt = 0;

			for (int i = 54; i < Tab.Length; i++)
			{
				Tab2[i] = Tab[Compt];
				Compt++;
			}

			File.WriteAllBytes(Nom + ".png", Tab2);

			ProcessStartInfo Sortir = new ProcessStartInfo(@Nom + ".png", "");
			Process.Start(Sortir);
		}

		}
	}


		
	

