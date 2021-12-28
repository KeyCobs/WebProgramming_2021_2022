<template>
  <div class="Addsongs">
    <h1>{{ msg }}</h1>
    <h2>Essential Links</h2>
    <button v-on:click="navigate()">Home</button>
    <br>
    <br>
        <form v-on:submit="addSong">
          <input type="text" v-model="titleSong" placeholder="Song name">
          <input type="text" v-model="artist" placeholder="Artistname">
          <input type="text" v-model="spotifyLink" placeholder="Spotify Link">
          <button type="submit">Add</button>  
      </form>
      <br>
  </div>
</template>

<script>
    import router from '../router'
    import Vue from 'vue';
    import axioss from 'axios';
    import VueAxios from 'vue-axios' ;
    Vue.use(VueAxios,axioss);
export default {
  name: 'addSongs',
  data () {
    return {
      titleSong:undefined,
      artist:undefined,
      allArtist:undefined,
      spotifyLink:undefined,
      msg: 'Add a song'
    }
  },
  methods:
  {
      navigate()
      {
          
          router.push('home');
      },
      addSong(e)
      {
          e.preventDefault();

        Vue.axios.get('https://localhost:5001/Artist')
        .then((r)=>
        {
         this.allArtist = r.data;

          
          let idArtist = -1;
           for(let i=0; i< this.allArtist.length; i++)
           {
             if(this.allArtist[i].name.toLowerCase() === this.artist.toLowerCase())
             {
                idArtist = this.allArtist[i].id;
                break;
             }
           }

          if (idArtist === -1)
          {
            let artistAdd = {name: this.artist}
            Vue.axios.post('https://localhost:5001/Artist',artistAdd)
            .then((r)=>
            {
              Vue.axios.get('https://localhost:5001/Artist')
              .then((r)=>
              {
                console.log(r.data);
                this.allArtist = r.data;
                for(let i=0; i< this.allArtist.length; i++)
                {
                  if(this.allArtist[i].name.toLowerCase() === this.artist.toLowerCase())
                  {
                    idArtist = this.allArtist[i].id;
                    console.log(idArtist);
                    break;
                  }
                }
                
              })
            })
          }
          let songAdd = {title: this.titleSong, artist_id: idArtist, spotify: this.spotifyLink }
          console.log(songAdd);
          Vue.axios.post('https://localhost:5001/Songs',songAdd)
            .then((r)=>
            {
              console.log(r)
            })


      })
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
</style>
