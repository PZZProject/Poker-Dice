#include<conio.h>
#include<stdio.h>
#include<stdlib.h>
#include<time.h>




/**
 * \brief Funkcja losowania
 *
 * Funkcja ta losuje 5 liczb z zakresu 1-6 odpowiadaj¹cych wartoœci oczek na koœciach. Zapisywane s¹ tymczasowo do tablicy "rzut".
 */
void losowanie(int rzut[]){
	for(int i=0;i<5;i++)
	{
		rzut[i]=rand()%6+1;
	}

}


/**
 * \brief Funkcja wymiany
 *
 * Funkcja ta losuje losowe liczby z zakresu 1-6 dla wybranych elementów tablicy "rzut". Innymi s³owy, gracz wymienia ustalone przez siebie koœci. 
 * \param[in] n Ilosc wymienianych kosci
 * \param[in] wyraz Kosci które chcemy wymienic. Moze zawierac do 5 znaków, dlatego jest typu char. Litera 'x' oznacza, i¿ nie chcemy zmieniaæ ustawienia. 
 */

void wymiana_kosci(int n,int rzut[], char wyraz[]){

	for(int i=0;i<5;i++)
	{
		wyraz[i]='x';
	}
	printf("\nKtore kosci chcesz wymienic?(x-zadna)\n");
	scanf("%s",wyraz);
	
	if(wyraz[0]!='x'){
		for(int i=0;i<n;i++)
		{
			if (wyraz[i]=='1') { rzut[0]=rand()%6+1;}
			if (wyraz[i]=='2') { rzut[1]=rand()%6+1;}
			if (wyraz[i]=='3') { rzut[2]=rand()%6+1;}
			if (wyraz[i]=='4') { rzut[3]=rand()%6+1;}
			if (wyraz[i]=='5') { rzut[4]=rand()%6+1;}
		}
	}
}

/**
 * \brief Funkcja Wypisz
 *
 * Wypisuje liczby oczek w danym rzucie.
 */

void wypisz(int rzut[]){
	for(int i=0;i<5;i++)
		{
			printf("%d ",rzut[i]);
		}
}


/**
 * \brief Funkcja formularza
 *
 * Tutaj zapisywane s¹ punkty, które dany gracz uzyska³ oraz obliczana ich ilosc.
 * \param[in] tab Tablica z wynikami danego gracza.
 * \param[in] tab_obraz Tablica okreslajaca, czy dana kategoria by³a juz wczesniej wykorzystana ( 0 - nie, 1 - tak ). 
 * \param[in] a Wybrana kategoria
 * \param[in] kosci Tablica ta zlicza dane wystapienia oczek wedle pozycji w tabeli ( kosci[1] - liczba kosci o liczbie oczek 1 itd.. ). U³atwia liczenie punktacji.
 *
 */
 
 
void tablica_wynikow(int tab[],int tab_obraz[],char a, int kosci[]){
	
	int zm_pom1=0, zm_pom2=0;	
	PRZYDZIELANIE:
	switch(a){
		case 1:
			if(tab_obraz[0]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[0]=1*kosci[1];
				tab_obraz[0]=1;
			}
			break;
		case 2:
			if(tab_obraz[1]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[1]=2*kosci[2];
				tab_obraz[1]=1;
			}
			break;
		case 3:
			if(tab_obraz[2]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[2]=3*kosci[3];
				tab_obraz[2]=1;
			}
			break;
		case 4:
			if(tab_obraz[3]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[3]=4*kosci[4];
				tab_obraz[3]=1;
			}
			break;
		case 5:
			if(tab_obraz[4]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[4]=5*kosci[5];
				tab_obraz[4]=1;
			}
			break;
		case 6:
			if(tab_obraz[5]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[5]=6*kosci[6];
				tab_obraz[5]=1;
			}
			break;
		case 7:									// trojka
			if(tab_obraz[6]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				for(int i=1;i<7;i++){
					if(kosci[i]==3){ tab[6]=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]);	}
					if(kosci[i]==5 && tab_obraz[11]>0){tab[6]=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]); }
				}
				tab_obraz[6]=1;
			}
			break;
		case 8:									// kareta
			if(tab_obraz[7]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				for(int i=1;i<7;i++){
					if(kosci[i]==4){ tab[7]=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]);	}
					if(kosci[i]==5 && tab_obraz[11]>0){tab[7]=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]); }
				}
				tab_obraz[7]=1;
			}
			break;
		case 9:									// full
			if(tab_obraz[8]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				zm_pom1=0;
				zm_pom2=0;
				for(int i=1;i<7;i++){
					if(kosci[i]==3){ zm_pom1=1;	}
					if(kosci[i]==2){ zm_pom2=1;	}
					if(kosci[i]==5 && tab_obraz[11]>0){tab[8]=25; }
				}
				if(zm_pom1==1 && zm_pom2==1){ tab[8]=25;	}
				tab_obraz[8]=1;
			}
			break;
		case 10:								// maly strit
			if(tab_obraz[9]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0){ tab[9]=30;}
				if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ tab[9]=30;}
				if(kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ tab[9]=30;}
				for(int i=1;i<7;i++){
					if(kosci[i]==5 && tab_obraz[11]>0){tab[9]=30; }
				}
				tab_obraz[9]=1;
			}
			break;
		case 11:								// duzy strit
			if(tab_obraz[10]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ tab[10]=40;}
				if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ tab[10]=40;}
				for(int i=1;i<7;i++){
					if(kosci[i]==5 && tab_obraz[11]>0){tab[10]=40; }
				}
				tab_obraz[10]=1;
			}
			break;
		case 12:								// general
			if(tab_obraz[11]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				for(int i=1;i<7;i++){
					if(kosci[i]==5){ tab[11]=50;}
				}
				tab_obraz[11]=1;
			}
			break;
		case 13:								// szansa
			if(tab_obraz[12]>0){
				printf("Juz wykozystales ta mozliwosc. Podaj inna: ");
				scanf("%d",&a);
				goto PRZYDZIELANIE;
			} 
			else 
			{
				tab[12]=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]);
				for(int i=1;i<7;i++){
					if(kosci[i]==5 && tab_obraz[11]>0){tab[7]=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]); }
				}
				tab_obraz[12]=1;
			}
			break;
		default:
			printf("Zla opcja! Podaj inna: ");
			scanf("%d",&a);
			goto PRZYDZIELANIE;
			break;
	}
	
}

/**
 * \brief Wyswietlenie formularza
 *
 * Funkcja ta wyswietla punktacje danego gracza
 */
void wypisz_wyniki(int tab[], int tab_2_obraz[]){
	printf("\n");
	printf("1. Jedynki:        %d  %d\n",tab[0], tab_2_obraz[0]);
	printf("2. Dwojki:         %d  %d\n",tab[1], tab_2_obraz[1]);
	printf("3. Trojki:         %d  %d\n",tab[2], tab_2_obraz[2]);
	printf("4. Czworki:        %d  %d\n",tab[3], tab_2_obraz[3]);
	printf("5. Piatki:         %d  %d\n",tab[4], tab_2_obraz[4]);
	printf("6. Szostki:        %d  %d\n",tab[5], tab_2_obraz[5]);
	printf("\n7. Trojka:         %d  %d\n",tab[6], tab_2_obraz[6]);
	printf("8. Kareta:         %d  %d\n",tab[7], tab_2_obraz[7]);
	printf("9. Full:           %d  %d\n",tab[8], tab_2_obraz[8]);
	printf("10. Maly strit:    %d  %d\n",tab[9], tab_2_obraz[9]);
	printf("11. Duzy strit:    %d  %d\n",tab[10], tab_2_obraz[10]);
	printf("12. General:       %d  %d\n",tab[11], tab_2_obraz[11]);
	printf("13. Szansa:        %d  %d\n",tab[12], tab_2_obraz[12]);
	
}

/**
 * \brief Sumowanie punktacji
 *
 * Tutaj nastepuje sumowanie punktow i premii. Na poczatku sprawdza, czy jest premia w gornej czesci, dopiero potem nastepuje faktyczne zliczanie.
 */
 
int sumowanie(int tab[]){
	int suma;
	suma=0;
	for(int i=0;i<6;i++){
	 	suma=suma+tab[i];
	}
	if(suma>62){ suma=35;} else { suma=0; }
	for(int i=0;i<13;i++){
		suma=suma+tab[i];
	}
	
	return suma;
	
}


//----------------------------------------------------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------------------------------------------------


 
void SI(int tab_2[], int tab_2_obraz[], int kosci[], int a){
	int max=-1;
	int wynik=0;
	wynik=1*kosci[1];
	if (max<wynik && tab_2_obraz[0]==0){
		max=wynik;
		a=1;
	}
	wynik=2*kosci[2];
	if (max<wynik && tab_2_obraz[1]==0){
		max=wynik;
		a=2;
	}
	wynik=3*kosci[3];
	if (max<wynik && tab_2_obraz[2]==0 ){
		max=wynik;
		a=3;
	}
	wynik=4*kosci[4];
	if (max<wynik && tab_2_obraz[3]==0){
		max=wynik;
		a=4;
	}
	wynik=5*kosci[5];
	if (max<wynik && tab_2_obraz[4]==0 ){
		max=wynik;
		a=5;
	}
	wynik=6*kosci[6];
	if (max<wynik && tab_2_obraz[5]==0){
		max=wynik;
		a=6;
	}
	wynik=0;
	for(int i=1;i<7;i++){
		if(kosci[i]==3){ wynik=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]);	}
		if(kosci[i]==5 && tab_2_obraz[11]>0){wynik=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]); }
	}
	if (max<wynik && tab_2_obraz[6]==0){
		max=wynik;
		a=7;
	}
	wynik=0;
	for(int i=1;i<7;i++){
		if(kosci[i]==4){ wynik=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]);	}
		if(kosci[i]==5 && tab_2_obraz[11]>0){wynik=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]); }	
		}
	if (max<wynik && tab_2_obraz[7]==0){
		max=wynik;
		a=8;
	}
	wynik=0;
	int zm_pom1=0;
	int zm_pom2=0;
	for(int i=1;i<7;i++){
		if(kosci[i]==3){ zm_pom1=1;	}
		if(kosci[i]==2){ zm_pom2=1;	}
		if(kosci[i]==5 && tab_2_obraz[11]>0){wynik=25; }
	}
	if(zm_pom1==1 && zm_pom2==1){ wynik=25;	}
		if (max<wynik && tab_2_obraz[8]==0){
		max=wynik;
		a=9;
	}
	wynik=0;
	if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0){ wynik=30;}
	if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ wynik=30;}
	if(kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ wynik=30;}
	for(int i=1;i<7;i++){
		if(kosci[i]==5 && tab_2_obraz[11]>0){wynik=30; }
	}
	if (max<wynik && tab_2_obraz[9]==0){
		max=wynik;
		a=10;
	}
	wynik=0;
	if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ wynik=40;}
	if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ wynik=40;}
	for(int i=1;i<7;i++){
		if(kosci[i]==5 && tab_2_obraz[11]>0){wynik=30; }
	}
	if (max<wynik && tab_2_obraz[10]==0){
		max=wynik;
		a=11;
	}
	wynik=0;	
	for(int i=1;i<7;i++){
		if(kosci[i]==5){ wynik=50;}
	}
	if (max<wynik && tab_2_obraz[11]==0){
	max=wynik;
	a=12;
    }
    wynik=0;
    wynik=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]);
	for(int i=1;i<7;i++){
		if(kosci[i]==5 && tab_2_obraz[11]>0){wynik=kosci[1]+(2*kosci[2])+(3*kosci[3])+(4*kosci[4])+(5*kosci[5])+(6*kosci[6]); }
	}
	if (max<wynik && tab_2_obraz[12]==0){
	max=wynik;
	a=13;
    }
    wynik=0;
    	tablica_wynikow(tab_2,tab_2_obraz,a,kosci);
    
}

/**
 * \brief Przebieg gry
 *
 * Wpierw nastepuje inicjalizacja tablic.
 * \attention Uzylem tutaj wskaznikow, ale mozna je zamienic na zwykle tablice. Chcialem w zarysie pokazac jak ma to wygladac.
 *            Dlatego dla ulatwienia uzylem wskaznikow, ale nic nie stoi na przeszkodzie by zamienic je na zwykle tablice, nawet globalne, by nie odnosic sie do funkcji.
 */
int main(){
	int *rzut;
	rzut=(int *)malloc(sizeof(int)*5);
	int *kosci;
	kosci=(int *)malloc(sizeof(int)*7);
	int *tab_1;
	tab_1=(int *)malloc(sizeof(int)*13);
		int *tab_1_obraz;
		tab_1_obraz=(int *)malloc(sizeof(int)*13);
	int *tab_2;
	tab_2=(int *)malloc(sizeof(int)*13);
		int *tab_2_obraz;
		tab_2_obraz=(int *)malloc(sizeof(int)*13);
	char wyraz[5];
	int i,tura,n,k,c;
	char a,z;
	
	START:
	system("cls");
	printf("\n                                 ! GRA KOSCI !\n");
	printf("\n                                 1. Nowa gra");
	printf("\n                                 2. Nowa gra z botem");
	printf("\n                                 3. Wyjdz");
	printf("\n\n                               Co chcesz wybrac?");
	printf("\n                                      ");
	scanf("%c",&z);
	getchar();
	srand(time(NULL));
if(z=='3'){ goto KONIEC;}
if(z=='1' || z=='2'){

	tura=0;	
	for(i=0;i<7;i++){
		kosci[i]=0;
	}
		for(i=0;i<13;i++){
		tab_1[i]=0;
		tab_1_obraz[i]=0;
		tab_2[i]=0;
		tab_2_obraz[i]=0;
	}
}


	while(tura!=13){

		system("cls");
		printf("TURA %d\n\nGRACZ 1 !!! \n",(tura+1));
		losowanie(rzut);
		printf("Kosci: ");
		wypisz(rzut);
		wymiana_kosci(5,rzut,wyraz);
		printf("\n");
		if(wyraz[0]!='x'){
			printf("Kosci: ");
			wypisz(rzut);
			wymiana_kosci(5,rzut,wyraz);
			printf("\n");
		}
		printf("\n");
	
		for(i=0;i<7;i++){
			kosci[i]=0;
		}
		for(i=0;i<5;i++){
			kosci[rzut[i]]=kosci[rzut[i]]+1;
		}
	
		system("cls");
		printf("Wyniki GRACZA 1:\n\n");
		printf("Kosci: ");
		wypisz(rzut);
		wypisz_wyniki(tab_1, tab_1_obraz);
		printf("\nWybierz pozycje: ");
		scanf("%d",&a);	
	
		tablica_wynikow(tab_1,tab_1_obraz,a,kosci);
	
	
	
	
		system("cls");
		printf("TURA: %d\n\nGRACZ 2 !!! \n",(tura+1));
		losowanie(rzut);
		printf("Kosci: ");
		wypisz(rzut);
		if(z=='1'){
		wymiana_kosci(5,rzut,wyraz);
		printf("\n");
		if(wyraz[0]!='x'){
			printf("Kosci: ");
			wypisz(rzut);
			wymiana_kosci(5,rzut,wyraz);
			printf("\n");
		}}
		printf("\n");
	
		for(i=0;i<7;i++){
			kosci[i]=0;
		}
		for(i=0;i<5;i++){
			kosci[rzut[i]]=kosci[rzut[i]]+1;
		}
        if(z=='2'){ SI(tab_2, tab_2_obraz, kosci, a); }
		system("cls");
		printf("Wyniki GRACZA 2:\n\n");
		printf("Kosci: ");
		wypisz(rzut);
		wypisz_wyniki(tab_2, tab_2_obraz);
	if(z=='1'){
	printf("\nWybierz pozycje: ");
		scanf("%d",&a);	
		tablica_wynikow(tab_2,tab_2_obraz,a,kosci);
	}


    if(z=='2'){
    printf("\nWcisnij 0, by kontynuowaæ: ");
    scanf("%d",&c);	
	}	
	
	
		tura=tura+1;
	

	}



	system("cls");
	printf("\nGRACZ 1 uzyskal %d pkt", sumowanie(tab_1));
	printf("\nGRACZ 2 uzyskal %d pkt", sumowanie(tab_2));



	KONIEC:
	free(rzut);
	free(kosci);
	free(tab_1);
	free(tab_1_obraz);
	free(tab_2);
	free(tab_2_obraz);
	getchar();
	return 0;
}
