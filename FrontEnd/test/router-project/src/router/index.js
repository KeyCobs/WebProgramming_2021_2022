import Vue from 'vue'
import Router from 'vue-router'
import home from '@/components/home'
import addSongs from '@/components/addSongs'
import vote from '@/components/vote'
import TopSongs from '@/components/TopSongs'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: "/",
            redirect: {
                name: "home"
            }
        },
        {
            path: '/home',
            name: 'home',
            component: home
        },
        {
            path: '/addSongs',
            name: 'addSongs',
            component: addSongs
        },
        {
          path: '/vote',
          name: 'vote',
          component: vote
        },
        {
          path: '/TopSongs',
          name: 'TopSongs',
          component: TopSongs
        }


    ]
})