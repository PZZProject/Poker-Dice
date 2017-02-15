/*
    Nie dodawa³em ¿adnych "include", ze wzglêdu na owe problemy z kompilacj¹. Poni¿szy kod dzia³a - sprawdzi³em.
	Poni¿szy skrypt dzia³a oczywiœcie, je¿eli tablica zajêtoœci "tab_obraz" oraz tablica zliczaj¹ca "kosci" s¹ w projekcie. 
    Trzeba tylko podpi¹æ tablicê "czy_podswietlic" do formularza.
    
*/
void Podswietlanie(int tab_obraz[], int kosci[]){ //Tab_obraz odpowiada za wczeœniejsze u¿ycie - jak coœ ju¿ zosta³o u¿yte, nie mo¿e byæ podswietlone, nawet jak jest 0 pkt
	int zm_pom1=0, zm_pom2=0; // potrzebne do Fulla
	int czy_podswietlic[13]; 
	for(int i=0; i<13; i++){ // Zerowanie tablicy czy_podswietlic na samym pocz¹tku
		czy_podswietlic[i]=0;
	}
	for(int i=0; i<6; i++){	// Sprawdzanie pierwszych wierszy formularza ( od jedynek do 6 )
    	if((kosci[i+1]>0)&&tab_obraz[i]==0){
	    	czy_podswietlic[i]=1;
	   }
    }
	if(tab_obraz[6]==0){ // Trójka
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
    if(tab_obraz[9]==0){ // Ma³y Strit
	    if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0){ czy_podswietlic[9]=1;}
		if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ czy_podswietlic[9]=1;}
		if(kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ czy_podswietlic[9]=1;}
		for(int i=1;i<7;i++){
			if(kosci[i]==5 && tab_obraz[11]>0){ czy_podswietlic[9]=1; }
		}
    }
    if(tab_obraz[10]==0){ // Du¿y Strit
        if(kosci[1]>0 && kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0){ czy_podswietlic[10]=1;}
		if(kosci[2]>0 && kosci[3]>0 && kosci[4]>0 && kosci[5]>0 && kosci[6]>0){ czy_podswietlic[10]=1;}
		for(int i=1;i<7;i++){
			if(kosci[i]==5 && tab_obraz[11]>0){ czy_podswietlic[10]=1; }
		}
    }
    if(tab_obraz[11]==0){  // Genera³
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
