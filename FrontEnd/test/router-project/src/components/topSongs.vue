<template>
  <div class="TopSongs">
    <h1>{{ msg }}</h1>
    <div class="row">
        <div class="colum">
            <table border="1px">
                <tr class="colum">

                    <td >title</td>
                    <td >artist_id</td>
                    <td >Spotify link</td>
                    <td>Points</td>
                </tr>
                <tr class="colum" v-for="item in listSongs" v-bind:key="item.id">


                    <td >{{item.title}}</td>
                    <td>{{item.artist_id}}</td>
                    <td>{{item.spotify}}</td>
                    <td >{{item.id}}</td>
                    
                </tr>

            </table>
        </div>
    </div>
            <button v-on:click="navigate()">Home</button>
  </div>
</template>

<script>
//https://localhost:5001/Artist
//https://localhost:5001/Songs
//https://localhost:5001/Vote
//                <tr class="colum" v-for="(item,votes) in allvotesCount" v-bind:key="item[0].id">
    import router from '../router';
    import Vue from 'vue';
    import axioss from 'axios';
    import VueAxios from 'vue-axios' ;
    Vue.use(VueAxios,axioss);


export default 
{
  name: 'TopSongs',
   data () 
    {
        return { 
        listSongs:undefined,
        listArtist:undefined,
        listVotes:undefined,
        msg:'TopSong'}

    },
    mounted()
    {

        let count = 0;
        let temp = '';
 
        Vue.axios.get('https://localhost:5001/Artist')
        .then((respond)=>
        {
            this.listArtist=respond.data;
            //console.warn(respond.data);
            Vue.axios.get('https://localhost:5001/Vote')
            .then((r)=>
            {
                this.listVotes=r.data;
                Vue.axios.get('https://localhost:5001/Songs')
                .then((r)=>
                {       
                    this.listSongs=r.data;
                    let allvotesCount = new Array(this.listSongs.length);
                    for(let i =0; i<this.listSongs.length; i++)
                    {
                        for(let j =0; j<this.listArtist.length; j++)
                        {
                            if(this.listSongs[i].artist_id === this.listArtist[j].id)
                            {
                                this.listSongs[i].artist_id = this.listArtist[j].name;
                                break;
                            }
                        }
                        let allvotes = 0;
                        temp = this.listSongs[i]
                        for(let j=0; j <this.listVotes.length; j++)
                        {
                            
                            if(this.listSongs[i].id === this.listVotes[j].song_ID)
                            {
                                allvotes += this.listVotes[j].points
                                temp = this.listVotes[j];
                               
                            }
                        }
                        if(allvotes != 0)
                        {
                            allvotesCount[count] = new Array;
                            allvotesCount[count][0] = temp;
                            allvotesCount[count][1] = allvotes
                            count++;
                        }
                        
                    }  
      
                    allvotesCount = allvotesCount.sort(function(a,b)
                    {
                        return b[1] - a[1];
                    })
                    for(let j=0; j < allvotesCount.length; j++)
                    {
                        allvotesCount[j][0].points = allvotesCount[j][1];
                        let idVote = allvotesCount[j][0].song_ID;
                        for(let i =0; i<this.listSongs.length; i++)
                        {
                            if(idVote === this.listSongs[i].id)
                            {
                                temp = this.listSongs[j];
                                this.listSongs[i].id = allvotesCount[j][0].points;
                                this.listSongs[j] = this.listSongs[i];
                                this.listSongs[i] = temp;
                                break;
                            }
                        }
                    }  
                })
            })

        })


    
    },      
    methods:
    {
      navigate()
      {
          
          router.push('home');
      }
    }

      
   
 
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.row {
  display: flex;
}

.column {
  flex: 50%;
  padding: 5px;
}
table {
  border-collapse: collapse;
  border-spacing: 0;
  width: 100%;
  border: 1px solid #ddd;
}

th, td {
  text-align: left;
  padding: 16px;
}
</style>
