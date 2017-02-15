/*
    Nie dodawa�em �adnych "include", ze wzgl�du na owe problemy z kompilacj�. Poni�szy kod dzia�a - sprawdzi�em.
	Poni�szy skrypt dzia�a oczywi�cie, je�eli tablica zaj�to�ci "tab_obraz" oraz tablica zliczaj�ca "kosci" s� w projekcie. 
    Trzeba tylko podpi�� tablic� "czy_podswietlic" do formularza.
    
*/
void Podswietlanie(int tab_obraz[], int kosci[]){ //Tab_obraz odpowiada za wcze�niejsze u�ycie - jak co� ju� zosta�o u�yte, nie mo�e by� podswietlone, nawet jak jest 0 pkt
	int zm_pom1=0, zm_pom2=0; // potrzebne do Fulla
	int czy_podswietlic[13]; 
	for(int i=0; i<13; i++){ // Zerowanie tablicy czy_podswietlic na samym pocz�tku
		czy_podswietlic[i]=0;
	}
	for(int i=0; i<6; i++){	// Sprawdzanie pierwszych wierszy formularza ( od jedynek do 6 )
    	if((kosci[i+1]>0)&&tab_obraz[i]==0){
	    	czy_podswietlic[i]=1;
	   }
    }
	if(tab_obraz[6]==0){ // Tr�jka
	    for(int i=1;i<7;i++){
	        if(kosci[i]==3){ czy_podswietlic[6]=1;	}
	     	if(kosci[i]==5 && tab_obraz[11]>0){ czy_podswietlic[6]=1;}
	 	}
    } 
	if(tab_obraz[7]==0){ // Kareta
	    for(int i=1;i<7;i++){
	        if(kosci[i]==4){ czy_podswietlic[7]=1;	}
	     	if(kosci[i]==5 && tab_obraz[11]>0){ czy_podswietlic[7]=1;}
	 	}
    } 
    if(tab_obraz[8]==0){ // Full
	    for(int i=1;i<7;i++){
	    	if(kosci[i]==3){ zm_pom1=1;	}
	 	    if(kosci[i]==2){ zm_pom2=1;	}
		    if(kosci[i]==5 && tab_obraz[11]>0){zm_pom1=1; zm_pom2=1; }
	    }
	    if(zm_pom1==1 && zm_pom2==1){ czy_podswietlic[8]=1;	}
    }
    if(tab_obraz[9]==0){ // Ma�y Strit
	    if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0){ czy_podswietlic[9]=1;}
		if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ czy_podswietlic[9]=1;}
		if(kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ czy_podswietlic[9]=1;}
		for(int i=1;i<7;i++){
			if(kosci[i]==5 && tab_obraz[11]>0){ czy_podswietlic[9]=1; }
		}
    }
    if(tab_obraz[10]==0){ // Du�y Strit
        if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ czy_podswietlic[10]=1;}
		if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ czy_podswietlic[10]=1;}
		for(int i=1;i<7;i++){
			if(kosci[i]==5 && tab_obraz[11]>0){ czy_podswietlic[10]=1; }
		}
    }
    if(tab_obraz[11]==0){  // Genera�
        for(int i=1;i<7;i++){
			if(kosci[i]==5){ czy_podswietlic[11]=1; }
		}	
    }
    if(tab_obraz[12]==0){  // Szansa
 	   czy_podswietlic[12]=1;
    }
    // Testowe wypisywanie
	//for(int i=0; i<13; i++){
   // 	printf("%d ", czy_podswietlic[i]);
//	}
}
